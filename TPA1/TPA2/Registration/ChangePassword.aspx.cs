using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPA2.Registration
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPasswordResetLinkValid())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password Reset link has expired or is invalid";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ChangeUserPassword())
            {
                lblMessage.Text = "Password Changed Successfully!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Password Reset link has expired or is invalid";
            }
        }

        private bool IsPasswordResetLinkValid()
        {
            if (Request.QueryString["uid"] != null)
            {
                List<SqlParameter> paramList = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@GUID",
                        SqlDbType=SqlDbType.UniqueIdentifier,
                        Value = new Guid(Request.QueryString["uid"])
                    }
                };
                return ConnectionClass.ExecuteSP("spIsPasswordResetLinkValid", paramList);
            }
            else
            {
                return false;
            }
        }

        private bool ChangeUserPassword()
        {
            if (Request.QueryString["uid"] != null)
            {
                List<SqlParameter> paramList = new List<SqlParameter>()
                {
                    new SqlParameter()
                    {
                        ParameterName = "@GUID",
                        SqlDbType=SqlDbType.UniqueIdentifier,
                        Value = new Guid(Request.QueryString["uid"])
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Password",
                        //Value = FormsAuthentication.HashPasswordForStoringInConfigFile(txtNewPassword.Text, "SHA1")
                           Value = txtNewPassword.Text
                    }
                };
                return ConnectionClass.ExecuteSP("spChangePassword", paramList);
            }
            else
            {
                return false;
            }
        }

    }
}