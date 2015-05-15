using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPA2
{
    public partial class AddBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Today;
            }
        }
        /// <summary>
        /// function that populates the providers textbox autocompelete 
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns>list of providers</returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchProviders(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name from Providers where " +
                    "Name like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Providers = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Providers.Add(sdr["Name"].ToString());
                        }
                    }
                    conn.Close();
                    return Providers;
                }
            }
        }
        /// <summary>
        /// function that populates the Holders textbox autocompelete 
        /// </summary>
        /// <param name="prefixText"></param>
        /// <param name="count"></param>
        /// <returns>list of holders</returns>
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchHolders(string prefixText, int count)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Name from PolicyHolders where " +
                    "Name like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Holders = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Holders.Add(sdr["Name"].ToString());
                        }
                    }
                    conn.Close();
                    return Holders;
                }
            }
        }

        public static List<string> SearchPolicy(string Provider)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["DBCS"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Policy.ID FROM Policy JOIN PolicyHolders ON Policy.HolderID=(Select ID FROM PolicyHolders where Name=@SearchText); ";
                    cmd.Parameters.AddWithValue("@SearchText", Provider);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> Holders = new List<string>();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Holders.Add(sdr["ID"].ToString());
                        }
                    }
                    conn.Close();
                    return Holders;
                }
            }
        }

        protected void PHoldertxt_TextChanged(object sender, EventArgs e)
        {
            List<string> policy = SearchPolicy(PHoldertxt.Text);
            if (policy != null)
            {
                Policylist.DataSource = policy;
                Policylist.DataBind();
                Policylist.Enabled = true;
            }

        }
/// <summary>
/// TODO:Add_Click need the empid and the batch type to be passed to the SP
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                int batchid=-1;
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager
                            .ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "spAddBatchAndReturnID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@policy", Policylist.SelectedValue);
                        cmd.Parameters.AddWithValue("@creationdate", DateTime.Today);
                        //////////////////////////////////////////////////
                        ///// fe moshkelaaa fe el login 3andy ma3rfsh men eih by2oly fe "Redirect Loop" f wa2ft el authorization w bel taly mafesh cookie 
                        //////////////////////////////////////////////////
                        cmd.Parameters.AddWithValue("@empid", Session["EmpID"]);
                        //////////////////////////////////////////////////
                        cmd.Parameters.AddWithValue("@receivingdate", Calendar1.SelectedDate);
                        cmd.Parameters.AddWithValue("@providername", Providertxt.Text);
                        if(RadioButtonList1.SelectedIndex==0)
                        {
                            cmd.Parameters.AddWithValue("@batchType", "In Patient");
                        }
                        else if (RadioButtonList1.SelectedIndex == 1)
                        {
                            cmd.Parameters.AddWithValue("@batchType", "Out Patient");
                        }
                        cmd.Connection = conn;
                        conn.Open();
                        //cmd.ExecuteNonQuery();
                        //cmd.Parameters.Clear();
                        //cmd.CommandText = "SELECT SCOPE_IDENTITY(); ";
                        batchid=Convert.ToInt32((cmd.ExecuteScalar()));
                    }
                    conn.Close();
                }
                resultlbl.Text = "New Batch Has Been Added Succesfully";
                if(batchid !=-1)
                {
                    Response.Redirect("~/Batches/Batch.aspx?B=" + batchid);
                }
            }
            catch(Exception ex)
            {
                resultlbl.ForeColor = System.Drawing.Color.Red;
                resultlbl.Text = ex.Message;
            }
        }

    }
}