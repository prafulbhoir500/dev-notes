using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;

namespace WebApp.V1
{
    public partial class SignInV1 : System.Web.UI.Page
    {
        AppDB db = new AppDB();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            var user = db.UserInfos.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                string sessionId = Session.SessionID;
                Session["UserId"] = user.UserID;
                Session["SessionId"] = sessionId;

                LogUserLogin(user.UserID, sessionId);
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
            }
        }

        private void LogUserLogin(int userId, string sessionId)
        {
           
                var log = new UserLoginLog
                {
                    UserId = userId.ToString(),
                    LoginTime = DateTime.UtcNow,
                    IPAddress = HttpContext.Current.Request.UserHostAddress,
                    UserAgent = HttpContext.Current.Request.UserAgent,
                    SessionId = sessionId
                };

                db.UserLoginLogs.Add(log);
                db.SaveChanges();
        }
    }
}