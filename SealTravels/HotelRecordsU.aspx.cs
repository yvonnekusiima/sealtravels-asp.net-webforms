using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class HotelRecordsU : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                showhotelrecords();
            }
        }
        private void isuserloggedin()
        {
            if (Session["userloggedin"] == null || !Convert.ToBoolean(Session["userloggedin"]))
            {
                Response.Redirect("UserLogin.aspx");
            }
        }


        protected void showhotelrecords()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from HOTELBOOKING", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hotelrecords.DataSource = ds;
                        hotelrecords.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        hotelrecords.DataSource = ds;
                        hotelrecords.DataBind();

                        int columncount = hotelrecords.Rows[0].Cells.Count;
                        hotelrecords.Rows[0].Cells.Clear();
                        hotelrecords.Rows[0].Cells.Add(new TableCell());
                        hotelrecords.Rows[0].Cells[0].ColumnSpan = columncount;
                        hotelrecords.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed hotel bookings");
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

        protected void hotelrecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(hotelrecords.DataKeys[e.RowIndex].Value.ToString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from HOTELBOOKING where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                  
                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Deleted hotel booking");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    showhotelrecords();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }           
        }
        protected void hotelrecords_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                hotelrecords.EditIndex = e.NewEditIndex;
                showhotelrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }

        protected void hotelrecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(hotelrecords.DataKeys[e.RowIndex].Value.ToString());
                    GridViewRow row = hotelrecords.Rows[e.RowIndex];
                    TextBox name = (TextBox)row.Cells[1].Controls[0];
                    TextBox email = (TextBox)row.Cells[2].Controls[0];
                    TextBox travelers = (TextBox)row.Cells[3].Controls[0];
                    TextBox rooms = (TextBox)row.Cells[4].Controls[0];
                    TextBox roomtype = (TextBox)row.Cells[5].Controls[0];
                    TextBox checkin = (TextBox)row.Cells[6].Controls[0];
                    TextBox checkout = (TextBox)row.Cells[7].Controls[0];
                    TextBox contact = (TextBox)row.Cells[8].Controls[0];
                    TextBox amount = (TextBox)row.Cells[9].Controls[0];
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update HOTELBOOKING set Name='" + name.Text + "', Email='" + email.Text + "', Travelers='" + travelers.Text + "', Rooms='" + rooms.Text + "', RoomType='" + roomtype.Text + "', CheckIn='" + checkin.Text + "', CheckOut='" + checkout.Text + "', Contact='" + contact.Text + "', Amount='" + amount.Text + "' where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();

                    hotelrecords.EditIndex = -1;
                    
                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Updated hotel booking");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    showhotelrecords();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }            
        }
        protected void hotelrecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                hotelrecords.PageIndex = e.NewPageIndex;
                showhotelrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void hotelrecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                hotelrecords.EditIndex = -1;
                showhotelrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
    }
}
