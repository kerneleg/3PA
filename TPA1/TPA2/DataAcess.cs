using System.Data;
using System.Data.SqlClient;
namespace TPA2.Batches
{
    public static class DataAcess
    {
        public static DataTable GetBatchData(int BatchID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0]= new SqlParameter("BatchID",BatchID);
            //DBconnection db = new DBconnection();
            DataTable dt= DBconnection.executeSelectQuery("GetBatchData", sqlParameters, true);
            return dt;
        }
    }
}