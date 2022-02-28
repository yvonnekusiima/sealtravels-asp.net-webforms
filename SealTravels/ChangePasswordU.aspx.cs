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
    public partial class ChangePasswordU : System.Web.UI.Page
    {
        byte b;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["userloggedin"])))
            {
                Response.Redirect("UserLogin.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    username2.Value = string.Format(Session["Username"].ToString());
                }
            }
        }
        protected void changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from Users", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (decryptpassword(currentpassword.Value) == sdr["Password"].ToString())
                        {
                            b = 1;
                        }
                    }
                    sdr.Close();

                    if (b == 1)
                    {
                        conn.Open();
                        cmd = new SqlCommand("update Users set Password=@Password where Username='" + username.Value + "'", conn);
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@Password"].Value = encryptpassword(newpassword.Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("<script> alert('Password changed successfully') </script>");
                    }
                    else
                    {
                        Response.Write("<script> alert('Current Password incorrect') </script>");
                    }

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Changed Password");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
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
