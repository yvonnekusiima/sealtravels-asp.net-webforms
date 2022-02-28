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
    public partial class FlightPaymentRecordsU : System.Web.UI.Page
    {
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
                    username.Value = string.Format(Session["Username"].ToString());
                }
            }
            if (!IsPostBack)
            {
                showflightpaymentrecords();
            }
        }
        protected void showflightpaymentrecords()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from FLIGHTPAYMENTS", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flightpaymentrecords.DataSource = ds;
                        flightpaymentrecords.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        flightpaymentrecords.DataSource = ds;
                        flightpaymentrecords.DataBind();

                        int columncount = flightpaymentrecords.Rows[0].Cells.Count;
                        flightpaymentrecords.Rows[0].Cells.Clear();
                        flightpaymentrecords.Rows[0].Cells.Add(new TableCell());
                        flightpaymentrecords.Rows[0].Cells[0].ColumnSpan = columncount;
                        flightpaymentrecords.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed flight payments");
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

        protected void flightpaymentrecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(flightpaymentrecords.DataKeys[e.RowIndex].Value.ToString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from FLIGHTPAYMENTS where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    showflightpaymentrecords();

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Deleted flight payment");
                    string hostname = Dns.GetHostName();
                    string ipaddress;
                    ipaddress = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ipaddress))
                    {
                        ipaddress = Request.UserHostAddress;
                    }
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
        protected void flightpaymentrecords_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                flightpaymentrecords.EditIndex = e.NewEditIndex;
                showflightpaymentrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }

        protected void flightpaymentrecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(flightpaymentrecords.DataKeys[e.RowIndex].Value.ToString());
                    GridViewRow row = flightpaymentrecords.Rows[e.RowIndex];
                    TextBox name = (TextBox)row.Cells[1].Controls[0];
                    TextBox email = (TextBox)row.Cells[2].Controls[0];
                    TextBox paymentmethod = (TextBox)row.Cells[3].Controls[0];
                    TextBox cardnumber = (TextBox)row.Cells[4].Controls[0];
                    TextBox cvv = (TextBox)row.Cells[5].Controls[0];
                    TextBox expirydate = (TextBox)row.Cells[7].Controls[0];
                    TextBox amount = (TextBox)row.Cells[8].Controls[0];
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update FLIGHTPAYMENTS set Name='" + name.Text + "', Email='" + email.Text + "', PaymentMethod='" + paymentmethod.Text + "', CardNumber='" + cardnumber.Text + "', CVV='" + cvv.Text + "', ExpiryDate='" + expirydate.Text + "', Amount='" + amount.Text + "' where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    flightpaymentrecords.EditIndex = -1;
                    showflightpaymentrecords();

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Updated flight payment");
                    string hostname = Dns.GetHostName();
                    string ipaddress;
                    ipaddress = Request.UserHostAddress;
                    if (string.IsNullOrEmpty(ipaddress))
                    {
                        ipaddress = Request.UserHostAddress;
                    }
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
        protected void flightpaymentrecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                flightpaymentrecords.PageIndex = e.NewPageIndex;
                showflightpaymentrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void flightpaymentrecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                flightpaymentrecords.EditIndex = -1;
                showflightpaymentrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
    }
}
