using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.V1.Services
{
    /// <summary>
    /// Summary description for LogoutHandler
    /// </summary>
    public class LogoutHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session == null)
            {
                return; // Prevent null reference issues
            }
            string sessionId = context.Session["SessionId"]?.ToString();
            string userId = context.Session["UserId"]?.ToString();

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}