using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace SealTravels
{
    public partial class FlightTicketU : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PassengerName"] != null)
                {
                    passengername.Value = string.Format(Session["PassengerName"].ToString());
                }
                if (Session["Email"] != null)
                {
                    email.Value = string.Format(Session["Email"].ToString());
                }
                if (Session["Contact"] != null)
                {
                    contact.Value = string.Format(Session["Contact"].ToString());
                }
                if (Session["LeavingFrom"] != null)
                {
                    leavingfrom.Value = string.Format(Session["LeavingFrom"].ToString());
                }
                if (Session["GoingTo"] != null)
                {
                    goingto.Value = string.Format(Session["GoingTo"].ToString());
                }
                if (Session["Airline"] != null)
                {
                    airline.Value = string.Format(Session["Airline"].ToString());
                }
                if (Session["TravelClass"] != null)
                {
                    travelclass.Value = string.Format(Session["TravelClass"].ToString());
                }
            }
        }

        protected void saveticket_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("spFLIGHTTICKETS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PassengerName", passengername.Value);
                    cmd.Parameters.AddWithValue("@Status", status.Value);
                    cmd.Parameters.AddWithValue("@Contact", contact.Value);
                    cmd.Parameters.AddWithValue("@LeavingFrom", leavingfrom.Value);
                    cmd.Parameters.AddWithValue("@GoingTo", goingto.Value);
                    cmd.Parameters.AddWithValue("@Email", email.Value);
                    cmd.Parameters.AddWithValue("@Airline", airline.Value);
                    cmd.Parameters.AddWithValue("@TravelClass", travelclass.Value);
                    cmd.Parameters.AddWithValue("@Flight", flight.Value);
                    cmd.Parameters.AddWithValue("@Seat", seat.Value);
                    cmd.Parameters.AddWithValue("@CheckIn", checkin.Value);
                    cmd.Parameters.AddWithValue("@Gate", gate.Value);
                    cmd.Parameters.AddWithValue("@Date", date.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Flight Ticket generated')</script>");

                    Response.Redirect("FlightTicketRecordsA.aspx");

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Generated flight ticket");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                //errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }

        //protected void generateticket_Click(object sender, EventArgs e)
        //{
        //    string barcode = autogeneratebarcode(8);

        //    Image img = null;
        //    using (var ms = new MemoryStream())
        //    {
        //        var writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
        //        writer.Options.Width = 280;
        //        writer.Options.Height = 80;
        //        writer.Options.PureBarcode = true;
        //        img = writer.Write(barcode);
        //        img.Save(ms, ImageFormat.Jpeg);
        //        return File(ms.ToArray(), "image/jpeg");
        //    }
        //}
        //public string autogeneratebarcode(int BarcodeLength)
        //{
        //    string allowedchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    Random randombarcode = new Random();
        //    char[] chars = new char[BarcodeLength];
        //    int allowedcharscount = allowedchars.Length;
        //    for (int i = 0; i < BarcodeLength; i++)
        //    {
        //        chars[i] = allowedchars[(int)((allowedchars.Length) * randombarcode.NextDouble())];
        //    }
        //    return new string(chars);
        //}
    }
}
