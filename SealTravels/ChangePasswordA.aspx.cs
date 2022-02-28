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
    public partial class ChangePasswordA : System.Web.UI.Page
    {
        byte b;
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
                    administratorid2.Value = string.Format(Session["AdministratorId"].ToString());
                }
            }
        }
        
        protected void changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from ADMINISTRATOR", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (currentpassword.Value == sdr["Password"].ToString())
                        {
                            b = 1;
                        }
                    }
                    sdr.Close();

                    if (b == 1)
                    {
                        conn.Open();
                        cmd = new SqlCommand("update ADMINISTRATOR set Password=@Password where AdministratorId='" + administratorid.Value + "'", conn);
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@Password"].Value = newpassword.Value;
                        cmd.ExecuteNonQuery();
                        Response.Write("<script> alert('Password changed successfully') </script>");
                    }
                    else
                    {
                        Response.Write("<script> alert('Current Password incorrect') </script>");
                    }

                    SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                    cmd_al.CommandType = CommandType.StoredProcedure;
                    cmd_al.Parameters.AddWithValue("@AdministratorId", string.Format(Session["AdministratorId"].ToString()));
                    cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                    cmd_al.Parameters.AddWithValue("@Action", "Changed Password");
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
