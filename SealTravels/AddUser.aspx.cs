using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["administratorloggedin"])))
            {
                Response.Redirect("AdministratorLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["AdministratorId"] != null)
                {
                    administratorid.Value = string.Format(Session["AdministratorId"].ToString());
                }
            }
        }
        protected void addusers_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spUSERS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string agp = password.Value = autogeneratepassword(8);
                    cmd.Parameters.AddWithValue("@Username", username.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Value);
                    cmd.Parameters.AddWithValue("@Password", encryptpassword(agp.Trim()));
                    cmd.Parameters.AddWithValue("@DateAdded", date.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('User Added') </script>");
                   
                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Added User");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    sendemail();

                    Response.Redirect("UserRecords.aspx");
                }
            }
            catch(Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }

        public void sendemail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email.Value);
            mail.From = new MailAddress("vonworkug@gmail.com", "VONWORK UG");
            mail.Subject = "Seal Travels Login Credentials";
            mail.Body = "Your username is " + username.Value + "\n" + "Your password is " + password.Value;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("vonworkug@gmail.com", "vonworkug00!");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        public string autogeneratepassword(int PasswordLength)
        {
            string allowedchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            Random randompassword = new Random();
            char[] chars = new char[PasswordLength];
            int allowedcharscount = allowedchars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = allowedchars[(int)((allowedchars.Length) * randompassword.NextDouble())];
            }
            return new string(chars);
        }
        private string encryptpassword(string password)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }
    }
}
