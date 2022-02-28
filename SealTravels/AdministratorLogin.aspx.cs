using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class AdministratorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["administratorloggedin"] = false;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(s))
                {
                    SqlCommand cmd = new SqlCommand("select * from ADMINISTRATOR where AdministratorId=@AdministratorId and Password=@Password", conn);
                    cmd.Parameters.AddWithValue("@AdministratorId", administratorid.Value);
                    cmd.Parameters.AddWithValue("@Password", password.Value);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (dt.Rows.Count > 0)
                    {
                        if (captcha.Value.ToLower() == Session["CaptchaVerify"].ToString())
                        {
                            Session["administratorloggedin"] = true;
                            Session["AdministratorId"] = administratorid.Value.Trim();

                            SqlCommand cmd_al = new SqlCommand("spADMINISTRATORACTIVITYLOG", conn);
                            cmd_al.CommandType = CommandType.StoredProcedure;
                            cmd_al.Parameters.AddWithValue("@AdministratorId", administratorid.Value);
                            cmd_al.Parameters.AddWithValue("@DateTimestamp", DateTime.Now);
                            cmd_al.Parameters.AddWithValue("@Action", "Logged in");
                            string hostname = Dns.GetHostName();
                            string ipaddress = Request.UserHostAddress;
                            cmd_al.Parameters.AddWithValue("@HostName", hostname);
                            cmd_al.Parameters.AddWithValue("@IPAddress", ipaddress);
                            cmd_al.ExecuteNonQuery();
                            conn.Close();

                            Response.Redirect("AdministratorPage.aspx");
                        }
                        else
                        {
                            Response.Write("<script> alert('Captcha code incorrect'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('Administrator Id or Password incorrect'); </script>");
                    }
                }
            }
            catch(Exception ex)
            {
                errormessage.InnerText = "ERROR: " + ex.Message;
            }
        }
    }
}
