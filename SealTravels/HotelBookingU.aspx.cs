using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SealTravels
{
    public partial class HotelBookingU : System.Web.UI.Page
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
        }
        private void isuserloggedin()
        {
            if (Session["userloggedin"] == null || !Convert.ToBoolean(Session["userloggedin"]))
            {
                Response.Redirect("UserLogin.aspx");
            }
        }
    }
}
