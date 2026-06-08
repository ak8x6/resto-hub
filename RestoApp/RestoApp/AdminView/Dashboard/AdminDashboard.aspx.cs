using System;
using RestoApp.AdminRepo;

namespace RestoApp.AdminView
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        private AdminRepo.UserRepository _userRepo = new AdminRepo.UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("~/Authentication/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadStats();
            }
        }

        private void LoadStats()
        {
            litUserCount.Text = _userRepo.GetCount("Users").ToString();
            litReservationCount.Text = _userRepo.GetCount("Reservations").ToString();
            litItemCount.Text = _userRepo.GetCount("Items").ToString();
            litFeedbackCount.Text = _userRepo.GetCount("Feedbacks").ToString();
        }
    }
}
