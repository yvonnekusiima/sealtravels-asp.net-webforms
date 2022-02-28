using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userloggedin"] = false;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("select * from USERS where Username=@Username and Password=@Password", conn);
                    cmd.Parameters.AddWithValue("@Username", username.Value);
                    cmd.Parameters.AddWithValue("@Password", decryptpassword(password.Value.Trim()));
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (dt.Rows.Count > 0)
                    {
                        if (captcha.Value.ToLower() == Session["CaptchaVerify"].ToString())
                        {
                            Session["userloggedin"] = true;
                            Session["Username"] = username.Value.Trim();

                            SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                            cmd_al.CommandType = CommandType.StoredProcedure;
                            cmd_al.Parameters.AddWithValue("@Username", username.Value);
                            cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                            cmd_al.Parameters.AddWithValue("@Action", "Logged in");
                            string hostname = Dns.GetHostName();
                            string ipaddress = Request.UserHostAddress;
                            cmd_al.Parameters.AddWithValue("@HostName", hostname);
                            cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                            cmd_al.ExecuteNonQuery();
                            conn.Close();

                            Server.Transfer("UserPage.aspx");
                        }
                        else
                        {
                            Response.Write("<script> alert('Captcha code incorrect!'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('Username or Password incorrect!'); </script>");
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }           
        }
        private string decryptpassword(string password)
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
