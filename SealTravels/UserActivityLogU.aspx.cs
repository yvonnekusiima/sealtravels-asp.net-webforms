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
    public partial class UserActivityLogU : System.Web.UI.Page
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
                showuseractivitylog();
            }
        }
        private void isuserloggedin()
        {
            if (Session["userloggedin"] == null || !Convert.ToBoolean(Session["userloggedin"]))
            {
                Response.Redirect("UserLogin.aspx");
            }
        }
        protected void showuseractivitylog()
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select DateTimestamp,Action,HostName,IPAddress from USERACTIVITYLOG where  Username='" + string.Format(Session["Username"].ToString()) + "'", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);                    

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        useractivitylog.DataSource = ds;
                        useractivitylog.DataBind();
                    }
                    else
                    {
                        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                        useractivitylog.DataSource = ds;
                        useractivitylog.DataBind();
                        int columncount = useractivitylog.Rows[0].Cells.Count;
                        useractivitylog.Rows[0].Cells.Clear();
                        useractivitylog.Rows[0].Cells.Add(new TableCell());
                        useractivitylog.Rows[0].Cells[0].ColumnSpan = columncount;
                        useractivitylog.Rows[0].Cells[0].Text = "No Records Found";
                    }

                    SqlCommand cmd_al = new SqlCommand("spUSERACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@Username", string.Format(Session["Username"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Viewed User Activity Log");
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
