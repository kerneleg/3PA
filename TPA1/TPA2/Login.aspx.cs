using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TPA2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Loggedin"]==null)
            {
                ////finding the Nav associated with id 
                HtmlAnchor nav = (HtmlAnchor)Page.Master.FindControl("cd_menu_trigger");

                ////hiding the Control
                nav.Style.Add("display", "none");
            }
            
        }
        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            #region AuthenticateUser
            var querylist = ConnectionClass.AuthenticateUser(Usernametxt.Text,Passtxt.Text);
            
             /*Description
              * In Case Of Success Querylist Will Contain the Results From the Stored Procedure spAuthenticateUser
             else query list will return the error to be Logged or Something
             
            querylist[0].Value==RetryAttempts(int)
            querylist[1].Value==AccountLocked(0/1)
            querylist[2].Value==Authenticated(0/1)
            in case of error querylist will contain one item which has the error
            querylist[0].key==Error */
            if (querylist.Count>1)
            {
                if (Convert.ToBoolean(querylist[1].Value))
                {
                    ResultLbl.Text = "Account locked or Username doesn't match. Please contact administrator";
                }
                else if (querylist[0].Value > 0)
                {
                    int AttemptsLeft = (4 - querylist[0].Value);
                    ResultLbl.Text = "Invalid user name and/or password. " +
                        AttemptsLeft.ToString() + "attempt(s) left";
                }
                else if (Convert.ToBoolean(querylist[2].Value))
                {
                    FormsAuthentication.RedirectFromLoginPage(Usernametxt.Text, RemembermeCBox.Checked);
                }
            }
            else
            {
                ///Catching Errors
                foreach (var item in querylist)
                {
                    if (item.Value == -5)
                    {
                        ResultLbl.Text = item.Key;
                    }
                }
            }
            #endregion
        }
    }
}