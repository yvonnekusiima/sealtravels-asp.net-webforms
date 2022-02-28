using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class Shangri_laHotelU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isuserloggedin();
            }
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    username.Value = string.Format(Session["Username"].ToString());
                }
            }
        }
        private void isuserloggedin()
        {
            if (Session["userloggedin"] == null || !Convert.ToBoolean(Session["userloggedin"]))
            {
                Response.Redirect("UserLogin.aspx");
            }
        }

        protected void bookroom_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spHOTELBOOKING", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Hotel", hotelname.Value);
                    cmd.Parameters.AddWithValue("@Name", name.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Value);
                    cmd.Parameters.AddWithValue("@Travelers", travelers.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Rooms", rooms.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@RoomType", roomtype.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@CheckIn", checkin.Value);
                    cmd.Parameters.AddWithValue("@CheckOut", checkout.Value);
                    cmd.Parameters.AddWithValue("@Contact", contact.Value);
                    cmd.Parameters.AddWithValue("@Amount", amount.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Booked')</script>");
                   
                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Made hotel booking at Shangri-la Hotel");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    sendemail();

                    Response.Redirect("HotelRecordsU.aspx");
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }            
        }
        public void sendemail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email.Value);
            mail.From = new MailAddress("vonworkug@gmail.com", "VONWORK UG");
            mail.Subject = "Flight Booking";
            mail.Body = "Hello " + name.Value + ", your booking at " + hotelname.Value + " has been recieved." + "\n \n" + "BOOKING DETAILS \n" + "Name - " + name.Value + "\n" + "Travelers - " + travelers.SelectedItem.Value + "\n" + "Rooms - " + rooms.SelectedItem.Value + "\n" + "Room Type - " + roomtype.SelectedItem.Value + "Check-in - " + checkin.Value + "\n" + "Check-out - " + checkout.Value + "\n" + "Contact - " + contact.Value + "\n" + "Amount - " + amount.Value;
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
