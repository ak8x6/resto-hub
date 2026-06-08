using System;
using System.Web.UI.WebControls;
using RestoApp.AdminRepo;

namespace RestoApp.AdminView
{
    public partial class AdminFeedbacks : System.Web.UI.Page
    {
        private AdminRepo.FeedbackRepository _repo = new AdminRepo.FeedbackRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null || Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("~/Authentication/Login.aspx");
                return;
            }

            if (!IsPostBack) { BindGrid(); }
        }

        private void BindGrid()
        {
            gvFeedbacks.DataSource = _repo.GetAllFeedbacks();
            gvFeedbacks.DataBind();
        }

        protected void gvFeedbacks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int feedbackId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ApproveFeedback")
            {
                bool success = _repo.ApproveFeedback(feedbackId, true);
                ShowMessage(success ? "Review approved and now visible to customers." : "Failed to approve review.", success);
            }
            else if (e.CommandName == "RejectFeedback")
            {
                bool success = _repo.ApproveFeedback(feedbackId, false);
                ShowMessage(success ? "Review rejected and hidden from customers." : "Failed to reject review.", success);
            }
            else if (e.CommandName == "DeleteFeedback")
            {
                bool success = _repo.DeleteFeedback(feedbackId);
                ShowMessage(success ? "Review deleted permanently." : "Failed to delete review.", success);
            }
            BindGrid();
        }

        private void ShowMessage(string msg, bool isSuccess)
        {
            pnlMessage.Visible = true;
            pnlMessage.CssClass = isSuccess ? "alert alert-success" : "alert alert-danger";
            lblMessage.Text = msg;
        }
    }
}
