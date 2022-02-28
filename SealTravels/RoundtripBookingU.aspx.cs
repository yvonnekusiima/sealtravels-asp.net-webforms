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
    public partial class RoundtripBookingU : System.Web.UI.Page
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

        protected void bookflight_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spROUNDTRIPFLIGHTS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", name.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Value);
                    cmd.Parameters.AddWithValue("@Contact", contact.Value);
                    cmd.Parameters.AddWithValue("@TripType", triptype.Value);
                    cmd.Parameters.AddWithValue("@LeavingFrom", leavingfrom.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@GoingTo", goingto.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Departing", departing.Value);
                    cmd.Parameters.AddWithValue("@Returning", returning.Value);
                    cmd.Parameters.AddWithValue("@Adults", adults.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Children", children.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@FlightType", flighttype.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@TravelClass", travelclass.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Airline", airline.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Amount", amount.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Flight Booked')</script>");
                    
                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Booked roundtrip flight");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    sendemail();

                    Response.Redirect("RoundtripRecordsU");
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
            mail.Body = "Hello " + name.Value + ", your flight booking has been recieved." + "\n \n" + "BOOKING DETAILS: \n \n" + "Name - " + name.Value + "\n" + "Trip Type - " + triptype.Value + "\n" + "Leaving From - " + leavingfrom.SelectedItem.Value + "\n" + "Going To - " + goingto.SelectedItem.Value + "\n" + "Departing - " + departing.Value + "\n" + "Returning - " + returning.Value + "\n" + "Adults - " + adults.SelectedItem.Value + "\n" + "Children - " + children.SelectedItem.Value + "\n" + "Flight Type - " + flighttype.SelectedItem.Value + "\n" + "Airline - " + airline.SelectedItem.Value + "\n" + "Travel Class - " + travelclass.SelectedItem.Value + "\n" + "Contact - " + contact.Value + "\n" + "Amount - " + amount.Value;
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
