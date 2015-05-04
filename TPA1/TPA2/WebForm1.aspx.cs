using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TPA2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == (1).ToString())
            {
                ////finding the Nav associated with id 
                HtmlGenericControl list = (HtmlGenericControl)Page.Master.FindControl("hopahopa");

                ////hiding the Control
                list.Style.Add("display", "normal");
            }
            if (Request.QueryString["id"] == (2).ToString())
            {
                ////finding the Nav associated with id 
                HtmlGenericControl nav = (HtmlGenericControl)Page.Master.FindControl("Ul1");
                
                ////hiding the Control
                nav.Style.Add("display", "normal");
            }
        }
    }
}