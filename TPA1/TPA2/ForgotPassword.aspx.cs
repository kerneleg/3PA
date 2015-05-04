using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TPA2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
            {
                ////finding the Nav associated with id 
                HtmlAnchor nav = (HtmlAnchor)Page.Master.FindControl("cd_menu_trigger");

                ////hiding the Control
                nav.Style.Add("display", "none");
            }
        }

        protected void Forgotbtn_Click(object sender, EventArgs e)
        {
            int Result = ConnectionClass.ResetPassword(Username.Text);
            if (Result==1)
            {
                Resultlbl.ForeColor = System.Drawing.Color.Green;
                Resultlbl.Text="An email with instructions to reset your password is sent to your registered Email";
            }
            else if (Result == 0)
            {
                Resultlbl.ForeColor = System.Drawing.Color.Red;
                Resultlbl.Text = "Username not found!";
            }
            else
            {
                Resultlbl.ForeColor = System.Drawing.Color.Red;
                Resultlbl.Text = "Error Occured! ... Please contact administrator";
            }
        }
    }
}