using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            if (Session["UserType"] != null)
            {
                //prevent redirection to login page if the user already logged in
                string val=HttpContext.Current.Request.Url.LocalPath;
                if (val.Equals("/Login.aspx", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Request.UrlReferrer == null)
                    {
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        Response.Redirect("~" + Request.UrlReferrer.LocalPath.ToString() + "");
                    }
                }
                //show logout button
                Logout.Visible = true;
                Logout.Enabled = true;

                if (Session["UserType"].ToString() == "Admin")
                {
                    ////finding the Nav associated with id 
                    HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("test");

                    ////showing the Control
                    list.Style.Add("display", "normal");
                }
                else if (Session["UserType"].ToString() == "Under Processing" || Session["UserType"].ToString() == "Approval")
                {
                    ////finding the Nav associated with id 
                    HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("UnderProcessing");

                    ////showing the Control
                    list.Style.Add("display", "normal");
                }
            }
            else
            {
                //hide logout button
                Logout.Visible = false;
                Logout.Enabled = false;
                if (HttpContext.Current.Request.Url.LocalPath != "/Login.aspx")
                {
                    string PastPage = HttpContext.Current.Request.Url.LocalPath.ToString();
                    Response.Redirect("~/Login.aspx?pre=" + PastPage + "");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //sign out
            //FormsAuthentication.SignOut();

            //hide logout button
            /*if (Logout.Visible == true)
            {
                Logout.Visible = false;
                Logout.Enabled = false;
            }*/

            //clear cookies
            if (Session["UserType"] != null)
            {
                Session["UserType"] = null;
                Session["EmpName"] = null;
                Session["EmpID"] = null;
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}