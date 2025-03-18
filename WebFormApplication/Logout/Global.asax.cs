using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp.V1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            string userId = Session["UserId"]?.ToString();
            string sessionId = Session["SessionId"]?.ToString();

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(sessionId))
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

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}