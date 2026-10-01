using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experiment_5
{
    public partial class Leave : System.Web.UI.Page
    {
        [Serializable]
        private class LeaveEntry
        {
            public DateTime Date { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Designation { get; set; }
            public string Reason { get; set; }
            public DateTime SubmittedOn { get; set; }
            public string User { get; set; }
        }

        private const string SessionLeavesKey = "UserLeaves";

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
                var qd = Request.QueryString["date"];

                if (!string.IsNullOrEmpty(qd))
                {
                    lblDate.Text = qd;
                }

                BindLeaves();
            }
        }

        protected void calLeave_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = calLeave.SelectedDate.ToShortDateString();
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblDate.Text))
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Please select a date.";
                return;
            }

            DateTime date;

            if (!DateTime.TryParse(lblDate.Text, out date))
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Invalid date.";
                return;
            }

            var entry = new LeaveEntry
            {
                Date = date,
                Name = txtEmpName.Text?.Trim(),
                Department = txtEmpDept.Text?.Trim(),
                Designation = txtEmpDesig.Text?.Trim(),
                Reason = txtReason.Text?.Trim(),
                SubmittedOn = DateTime.Now,
                User = Session["User"].ToString()
            };

            var list = Session[SessionLeavesKey]
                as List<LeaveEntry>;

            if (list == null)
            {
                list = new List<LeaveEntry>();
            }

            list.Add(entry);

            Session[SessionLeavesKey] = list;

            lblResult.ForeColor = System.Drawing.Color.Green;
            lblResult.Text =
                "Leave application submitted successfully.";

            // Clear local fields except name/department (as desired)
            txtEmpDesig.Text = string.Empty;
            txtReason.Text = string.Empty;

            BindLeaves();
        }

        private void BindLeaves()
        {
            var list = Session[SessionLeavesKey]
                as List<LeaveEntry>
                ?? new List<LeaveEntry>();

            var user = Session["User"]?.ToString();

            var filtered = list
                .Where(x => x.User == user)
                .OrderByDescending(x => x.SubmittedOn)
                .ToList();

            gvLeaves.DataSource = filtered;
            gvLeaves.DataBind();
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