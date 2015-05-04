using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TPA2.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            //finding the div associated with id 
            HtmlAnchor nav = (HtmlAnchor)Page.Master.FindControl("cd_menu_trigger");

            //hiding the div
            //nav.Style.Add("display", "none");
            if (nav.Style["display"] == "none")
            {
                nav.Style.Add("display", "normal");
            }
            else
            {
                nav.Style.Add("display", "none");
            }
            
        }
    }
}