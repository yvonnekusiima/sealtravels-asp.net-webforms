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
    public partial class RoundtripRecordsA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isadministratorloggedin();
            }
            if (!IsPostBack)
            {
                if (Session["AdministratorId"] != null)
                {
                    administratorid.Value = string.Format(Session["AdministratorId"].ToString());
                }
            }
            if (!IsPostBack)
            {
                showroundtriprecords();
            }
        }
        private void isadministratorloggedin()
        {
            if (Session["administratorloggedin"] == null || !Convert.ToBoolean(Session["administratorloggedin"]))
            {
                Response.Redirect("AdministratorLogin.aspx");
            }
        }


        protected void showroundtriprecords()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from ROUNDTRIPFLIGHTS", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        roundtriprecords.DataSource = ds;
                        roundtriprecords.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        roundtriprecords.DataSource = ds;
                        roundtriprecords.DataBind();

                        int columncount = roundtriprecords.Rows[0].Cells.Count;
                        roundtriprecords.Rows[0].Cells.Clear();
                        roundtriprecords.Rows[0].Cells.Add(new TableCell());
                        roundtriprecords.Rows[0].Cells[0].ColumnSpan = columncount;
                        roundtriprecords.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed roundtrip flight bookings");
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
        protected void roundtriprecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(roundtriprecords.DataKeys[e.RowIndex].Value.ToString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from ROUNDTRIPFLIGHTS where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                  
                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Deleted roundtrip flight booking");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    showroundtriprecords();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void roundtriprecords_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                roundtriprecords.EditIndex = e.NewEditIndex;
                showroundtriprecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void roundtriprecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(roundtriprecords.DataKeys[e.RowIndex].Value.ToString());
                    GridViewRow row = roundtriprecords.Rows[e.RowIndex];
                    TextBox name = (TextBox)row.Cells[1].Controls[0];
                    TextBox email = (TextBox)row.Cells[2].Controls[0];
                    TextBox contact = (TextBox)row.Cells[3].Controls[0];
                    TextBox triptype = (TextBox)row.Cells[4].Controls[0];
                    TextBox leavingfrom = (TextBox)row.Cells[5].Controls[0];
                    TextBox goingto = (TextBox)row.Cells[6].Controls[0];
                    TextBox departing = (TextBox)row.Cells[7].Controls[0];
                    TextBox returning = (TextBox)row.Cells[8].Controls[0];
                    TextBox travelclass = (TextBox)row.Cells[9].Controls[0];
                    TextBox adults = (TextBox)row.Cells[10].Controls[0];
                    TextBox children = (TextBox)row.Cells[11].Controls[0];
                    TextBox flighttype = (TextBox)row.Cells[12].Controls[0];
                    TextBox airline = (TextBox)row.Cells[13].Controls[0];
                    TextBox amount = (TextBox)row.Cells[14].Controls[0];
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update ROUNDTRIPFLIGHTS set Name='" + name.Text + "', Email='" + email.Text + "', Contact='" + contact.Text + "', TripType='" + triptype.Text + "', LeavingFrom='" + leavingfrom.Text + "', GoingTo='" + goingto.Text + "', Departing='" + departing.Text + "', Returning='" + returning.Text + "', TravelClass='" + travelclass.Text + "', Adults='" + adults.Text + "', Children='" + children.Text + "', FlightType='" + flighttype.Text + "', Airline='" + airline.Text + "', Amount='" + amount.Text + "' where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();

                    roundtriprecords.EditIndex = -1;

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Updated roundtrip flight booking");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email.Text);
                    mail.From = new MailAddress("vonworkug@gmail.com", "VONWORK UG");
                    mail.Subject = "Flight Booking Update";
                    mail.Body = "Hello " + name.Text + ", your flight booking has been updated." + "\n \n" + "NEW BOOKING DETAILS: \n \n" + "Name - " + name.Text + "\n" + "Trip Type - " + triptype.Text + "\n" + "Leaving From - " + leavingfrom.Text + "\n" + "Going To - " + goingto.Text + "\n" + "Departing - " + departing.Text + "\n" + "Returning - " + returning.Text + "\n" + "Adults - " + adults.Text + "\n" + "Children - " + children.Text + "\n" + "Flight Type - " + flighttype.Text + "\n" + "Airline - " + airline.Text + "\n" + "Travel Class - " + travelclass.Text + "\n" + "Contact - " + contact.Text + "\n" + "Amount - " + amount.Text;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("vonworkug@gmail.com", "vonworkug00!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
             
                    showroundtriprecords();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }           
        }
        protected void roundtriprecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                roundtriprecords.PageIndex = e.NewPageIndex;
                showroundtriprecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }          
        }
        protected void roundtriprecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                roundtriprecords.EditIndex = -1;
                showroundtriprecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
    }
}
