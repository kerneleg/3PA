using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TPA2.Model;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
namespace TPA2.Batches
{
    public partial class Batch : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Batch_Model Batch_Model = Batch_Bus.GetData(int.Parse(Request.QueryString["B"]));
            BatchTitle.Text = Batch_Model.DisplayID;
            ProviderTxt.Text = Batch_Model.Provider.Name;
            BatchTypeTxt.Text = Batch_Model.Type;
            PHolderTxt.Text = Batch_Model.Policy.Holder.Name;
            PolicyTxt.Text = Batch_Model.Policy.ID.ToString();
            ReceivingDateTxt.Text = Batch_Model.ReceivingDate.Date.ToString();
            CreationDateTxt.Text = Batch_Model.CreationDate.Date.ToString();
            if (Batch_Model.StratingDate.Date == new DateTime(1, 1, 1))
            {
                StartingDateText.Text = "";
            }
            else
            {
                StartingDateText.Text = Batch_Model.StratingDate.Date.ToString();
            }
            if (Batch_Model.EndingDate.Date == new DateTime(1, 1, 1))
            {
                EndingDateText.Text = "";
            }
            else
            {
                EndingDateText.Text = Batch_Model.EndingDate.Date.ToString();
            }
            CreatorTxt.Text = Batch_Model.Creator.Name;
            #region GridsVisibilty
            
            if (Session["UserType"].ToString() == "Under Processing")
            {
                if(BatchTypeTxt.Text=="In Patient")
                {
                    UnderInPanel.Visible = true;
                }
                if (BatchTypeTxt.Text == "Out Patient")
                {
                    UnderOutPanel.Visible = true;
                }
                AddClaimPanel.Visible = true;
            }
            if (Session["UserType"].ToString() == "Approval")
            {
                if (BatchTypeTxt.Text == "In Patient")
                {
                    ApprovalInPanel.Visible = true;
                }
                if (BatchTypeTxt.Text == "Out Patient")
                {
                    ApprovalOutPanel.Visible = true;
                }
            }
            #endregion
        }
        /// <summary>
        /// function that populates the ClientName textbox autocompelete 
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns>list of Clients</returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchPatientName(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name from Clients where " +
                    "Name like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Patients = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Patients.Add(sdr["Name"].ToString());
                        }
                    }
                    conn.Close();
                    return Patients;
                }
            }
        }
        /// <summary>
        /// function that populates the ClientName textbox autocompelete 
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns>list of Clients</returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchPatientID(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select ID from Clients where " +
                    "ID like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> PatientsiD = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            PatientsiD.Add(sdr["ID"].ToString());
                        }
                    }
                    conn.Close();
                    return PatientsiD;
                }
            }
        }
        protected void ClientNameTxt_TextChanged(object sender, EventArgs e)
        {
            string id=string.Empty;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select ID from Clients where " +
                    "Name=@SearchText";
                    cmd.Parameters.AddWithValue("@SearchText", ClientNameTxt.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            id=sdr["ID"].ToString();
                        }
                    }
                    conn.Close();
                }
            }
            ClientIDTxt.Text = id;
        }

        protected void ClientIDTxt_TextChanged(object sender, EventArgs e)
        {
            string id = string.Empty;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name from Clients where " +
                    "ID=@SearchText";
                    cmd.Parameters.AddWithValue("@SearchText", ClientIDTxt.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            id = sdr["Name"].ToString();
                        }
                    }
                    conn.Close();
                }
            }
            ClientNameTxt.Text = id;
        }
       
    }
}