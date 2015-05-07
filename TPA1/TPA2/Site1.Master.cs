using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
namespace TPA2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.Header.DataBind();
        }
        protected void Page_Init(object sender, EventArgs e)
        {           
            //change nav bar on user type
             HttpCookie cookie = Request.Cookies["UserData"];
             if (cookie != null)
             {
                 //prevent redirection to login page if the user already logged in
                 if (HttpContext.Current.Request.Url.LocalPath == "/Login.aspx")
                 {
                     if (!IsPostBack)
                     {
                         Response.Redirect("~/WebForm1.aspx");
                     }
                 }
                 //hide logout button
                 Logout.Visible = true;
                 Logout.Enabled = true;

                 if (cookie["UserType"].ToString() == "Admin")
                 {
                     ////finding the Nav associated with id 
                     HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("test");

                     ////showing the Control
                     list.Style.Add("display", "normal");
                 }
                 else if (cookie["UserType"].ToString() == "UnderProcessing")
                 {
                     ////finding the Nav associated with id 
                     HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("UnderProcessing");

                     ////showing the Control
                     list.Style.Add("display", "normal");
                 }
             }
             else
             {
                 //show logout button
                 Logout.Visible = false;
                 Logout.Enabled = false;
             }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //sign out
            FormsAuthentication.SignOut();

            //hide logout button
            if (Logout.Visible == true)
            {
                Logout.Visible = false;
                Logout.Enabled = false;
            }

            //clear cookies
            if (Request.Cookies["UserData"] != null)
            {
                HttpCookie Cookie = new HttpCookie("UserData");
                Cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(Cookie);
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}