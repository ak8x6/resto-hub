using System;
using System.Web;

namespace RestoApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Remove auth cookie
            if (Request.Cookies["AuthToken"] != null)
            {
                HttpCookie cookie = new HttpCookie("AuthToken");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("~/Default.aspx");
        }
    }
}