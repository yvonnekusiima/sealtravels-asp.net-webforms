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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class FlightPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitpayment_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spFLIGHTPAYMENTS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", name.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Value);
                    cmd.Parameters.AddWithValue("@VisaCard", visacard.Value);
                    cmd.Parameters.AddWithValue("@AmericanExpress", americanexpress.Value);
                    cmd.Parameters.AddWithValue("@MasterCard", mastercard.Value);
                    cmd.Parameters.AddWithValue("@CardNumber", encrypt(cardnumber.Value));
                    cmd.Parameters.AddWithValue("@CVV", encrypt(cvv.Value));
                    cmd.Parameters.AddWithValue("@ExpiryDate", expirydate.Value);
                    cmd.Parameters.AddWithValue("@Amount", amount.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Flight Payment Submitted, Please check email for confirmation')</script>");

                    sendemail();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }                   
        }
        private string encrypt(string value)
        {
            string EncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            byte[] clearBytes = Encoding.Unicode.GetBytes(value);
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
                    value = Convert.ToBase64String(ms.ToArray());
                }
            }
            return value;
        }
		public void sendemail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email.Value);
            mail.From = new MailAddress("vonworkug@gmail.com", "VONWORK UG");
            mail.Subject = "Flight Booking";
            mail.Body = "Hello " + name.Value + ", your flight payment has been recieved." + "\n \n" + "PAYMENT DETAILS \n" + "Name - " + name.Value + "\n" + "Payment Method - " + americanexpress.Value + visacard.Value + mastercard.Value + "\n" + "Amount - " + amount.Value;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("vonworkug@gmail.com", "vonworkug00!");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
