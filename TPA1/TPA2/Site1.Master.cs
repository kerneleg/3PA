using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "Admin")
                {
                    ////finding the Nav associated with id 
                    HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("test");

                    ////showing the Control
                    list.Style.Add("display", "normal");
                }
                else if (Session["UserType"].ToString() == "UnderProcessing")
                {
                    ////finding the Nav associated with id 
                    HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("UnderProcessing");

                    ////showing the Control
                    //list.Style.Add("display", "normal");
                    list.Style["display"] = "normal";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}