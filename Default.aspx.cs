using System;
using System.Web;

namespace Experiment_5
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Restore from cookie if needed
            if (Session["User"] == null)
            {
                var auth = Request.Cookies["UserAuth"];

                if (auth != null && !string.IsNullOrEmpty(auth.Value))
                {
                    Session["User"] = HttpUtility.UrlDecode(auth.Value);
                }
            }

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            lblWelcome.Text = "Welcome, " + Session["User"].ToString();

            if (!IsPostBack)
            {
                lblDate.Text = string.Empty;
            }
        }

        protected void calMain_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = calMain.SelectedDate.ToShortDateString();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Ensure a date is selected
            var date = calMain.SelectedDate;

            if (date == DateTime.MinValue)
            {
                // No selection - redirect to Leave without date
                Response.Redirect("Leave.aspx", false);
            }
            else
            {
                Response.Redirect(
                    "Leave.aspx?date=" +
                    HttpUtility.UrlEncode(date.ToShortDateString()),
                    false);
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            var cookie = new HttpCookie("UserAuth")
            {
                Expires = DateTime.UtcNow.AddDays(-1)
            };

            Response.Cookies.Add(cookie);

            Response.Redirect("Login.aspx", false);
        }
    }
}