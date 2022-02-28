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
    public partial class AdministratorActivityLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["administratorloggedin"])))
            {
                Response.Redirect("AdministratorLogin.aspx");
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
                showadministratoractivitylog();
            }           
        }
      
        protected void showadministratoractivitylog()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from ADMINISTRATORACTIVITYLOG", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        administratoractivitylog.DataSource = ds;
                        administratoractivitylog.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        administratoractivitylog.DataSource = ds;
                        administratoractivitylog.DataBind();
                        int columncount = administratoractivitylog.Rows[0].Cells.Count;
                        administratoractivitylog.Rows[0].Cells.Clear();
                        administratoractivitylog.Rows[0].Cells.Add(new TableCell());
                        administratoractivitylog.Rows[0].Cells[0].ColumnSpan = columncount;
                        administratoractivitylog.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed Administrator Activity Log");
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
    }
}
