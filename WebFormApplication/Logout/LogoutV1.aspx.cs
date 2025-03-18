using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.V1
{
    public partial class LogoutV1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = Session["UserId"]?.ToString();
            string sessionId = Session["SessionId"]?.ToString();

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(sessionId))
            {
                LogUserLogout(userId, sessionId);
            }

            Session.Abandon();
            Response.Redirect("SignInV1.aspx");
        }

        private void LogUserLogout(string userId, string sessionId)
        {
            using (var db = new AppDB())
            {
                var log = db.UserLoginLogs.FirstOrDefault(l => l.UserId == userId && l.SessionId == sessionId && l.LogoutTime == null);
                if (log != null)
                {
                    log.LogoutTime = DateTime.UtcNow;
                    db.SaveChanges();
                }
            }
        }
    }
}