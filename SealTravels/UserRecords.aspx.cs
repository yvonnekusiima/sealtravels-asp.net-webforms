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
    public partial class UserRecords : System.Web.UI.Page
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
                showuserrecords();
            }
        }
        private void isadministratorloggedin()
        {
            if (Session["administratorloggedin"] == null || !Convert.ToBoolean(Session["administratorloggedin"]))
            {
                Response.Redirect("AdministratorLogin.aspx");
            }
        }

        protected void showuserrecords()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from USERS", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataTable.DataSource = ds;
                        dataTable.DataBind();
                        dataTable.UseAccessibleHeader = true;
                        dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        dataTable.DataSource = ds;
                        dataTable.DataBind();
                        int columncount = dataTable.Rows[0].Cells.Count;
                        dataTable.Rows[0].Cells.Clear();
                        dataTable.Rows[0].Cells.Add(new TableCell());
                        dataTable.Rows[0].Cells[0].ColumnSpan = columncount;
                        dataTable.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed users");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;              
            }
            
        }
        protected void userrecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(dataTable.DataKeys[e.RowIndex].Value.ToString());
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from USERS where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Deleted user");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    showuserrecords();
                }
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }           
        }
        protected void userrecords_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                dataTable.EditIndex = e.NewEditIndex;
                showuserrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void userrecords_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    int id = Convert.ToInt32(dataTable.DataKeys[e.RowIndex].Value.ToString());
                    GridViewRow row = dataTable.Rows[e.RowIndex];
                    TextBox username = (TextBox)row.Cells[1].Controls[0];
                    TextBox email = (TextBox)row.Cells[2].Controls[0];
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update USERS set Username='" + username.Text + "', Email='" + email.Text + "' where Id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    dataTable.EditIndex = -1;

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Updated user");
                    string hostname = Dns.GetHostName();
                    string ipaddress = Request.UserHostAddress;
                    cmd_al.Parameters.AddWithValue("@HostName", hostname);
                    cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                    cmd_al.ExecuteNonQuery();
                    conn.Close();

                    showuserrecords();
                }          
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void userrecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dataTable.PageIndex = e.NewPageIndex;
                showuserrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
        protected void userrecords_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                dataTable.EditIndex = -1;
                showuserrecords();
            }
            catch (Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
    }
}
