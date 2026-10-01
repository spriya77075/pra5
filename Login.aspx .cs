using System;
using System.Web;

namespace Experiment_5
{
    public partial class Login : System.Web.UI.Page
    {
        // Demo credential check - replace with real auth for production
        private bool ValidateCredentials(string user, string pass)
            => !string.IsNullOrWhiteSpace(user)
               && pass == "password";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

            var auth = Request.Cookies["UserAuth"];

            if (auth != null && !string.IsNullOrEmpty(auth.Value))
            {
                Session["User"] =
                    HttpUtility.UrlDecode(auth.Value);

                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text?.Trim();

            string pass = txtPass.Text ?? string.Empty;

            if (!ValidateCredentials(user, pass))
            {
                lblMsg.Text =
                    "Invalid credentials. (demo password: 'password')";

                return;
            }

            Session["User"] = user;

            if (chkRemember.Checked)
            {
                var cookie = new HttpCookie(
                    "UserAuth",
                    HttpUtility.UrlEncode(user))
                {
                    Expires = DateTime.UtcNow.AddDays(7),
                    HttpOnly = true
                };

                Response.Cookies.Add(cookie);
            }

            Response.Redirect("Default.aspx", false);
        }
    }
}