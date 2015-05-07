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
            //check if browser support cookies or not
            if (!IsPostBack)
            {
                if (Request.Browser.Cookies)
                {
                    //create test querystring to insure that it's first time to redirect to this page
                    if (Request.QueryString["CheckCookie"] == null)
                    {
                        HttpCookie cookie = new HttpCookie("TestCookie", "1");
                        Response.Cookies.Add(cookie);
                        Response.Redirect("~/Login.aspx?CheckCookie=1");
                    }
                    else
                    {
                        //check if the browser enable cookies or not
                        HttpCookie cookie = Request.Cookies["TestCookie"];
                        if (cookie == null)
                        {
                            CookieLbl.Text = "We have detect that the cookies are disabled in your browser, please enable cookies to use the system correctly.";
                        }
                    }
                }
                else
                {
                    CookieLbl.Text = "This browser doesn't support cookies, please install on of the modern browsers that support cookies.";
                }
            }
            if (Session["Loggedin"] == null)
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
            var querylist = ConnectionClass.AuthenticateUser(Usernametxt.Text, Passtxt.Text);

            /*Description
             * In Case Of Success Querylist Will Contain the Results From the Stored Procedure spAuthenticateUser
            else query list will return the error to be Logged or Something
             
           querylist[0].Value==RetryAttempts(int)
           querylist[1].Value==AccountLocked(0/1)
           querylist[2].Value==Authenticated(0/1)
           querylist[3].value=usertype
           querylist[4].value=employee name
           in case of error querylist will contain one item which has the error
           querylist[0].key==Error */
            if (querylist.Count > 1)
            {
                if (Convert.ToInt32(querylist[1].Value) == 1)
                {
                    ResultLbl.Text = "Account locked or Username doesn't match. Please contact administrator";
                }
                else if (Convert.ToInt32(querylist[0].Value) > 0)
                {
                    int AttemptsLeft = (4 - Convert.ToInt32(querylist[0].Value));
                    ResultLbl.Text = "Invalid user name and/or password. " +
                        AttemptsLeft.ToString() + "attempt(s) left";
                }
                else if (Convert.ToInt32(querylist[2].Value) == 1)
                {
                    //saving user type and the employee name in cookie 
                    HttpCookie cookie = new HttpCookie("UserData");
                    cookie["UserType"]=querylist[3].Value;
                    cookie["EmpName"] = querylist[4].Value;
                    
                    //set the expiration period of the cookie
                    cookie.Expires = DateTime.Now.AddDays(30);

                    Response.Cookies.Add(cookie);
                    FormsAuthentication.RedirectFromLoginPage(Usernametxt.Text, RemembermeCBox.Checked);
                }
            }
            else
            {
                ///Catching Errors
                foreach (var item in querylist)
                {
                    if (item.Value == "-5")
                    {
                        ResultLbl.Text = item.Key;
                    }
                }
            }
            #endregion
        }
    }
}