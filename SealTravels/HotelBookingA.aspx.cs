using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class HotelBookingA : System.Web.UI.Page
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
        }
        private void isadministratorloggedin()
        {
            if (Session["administratorloggedin"] == null || !Convert.ToBoolean(Session["administratorloggedin"]))
            {
                Response.Redirect("AdministratorLogin.aspx");
            }
        }
    }
}
