using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TPA2.Model;
namespace TPA2.Batches
{
    public static class Batch_Bus
    {
        public static Batch_Model GetData(int BatchID)
        {
            DataTable DT = new DataTable();
            DT = DataAcess.GetBatchData(BatchID);
            Batch_Model Batch_Object = new Batch_Model();
            foreach (DataRow Row in DT.Rows)
            {
                Batch_Object.ID = BatchID;
                Batch_Object.Provider.ID = int.Parse(Row["ProviderID"].ToString());
                Batch_Object.Provider.Name = Row["ProviderName"].ToString();
                Batch_Object.Policy.ID = int.Parse(Row["PolicyID"].ToString());
                Batch_Object.Policy.Holder.Name = Row["Holder"].ToString();
                if (Row["StartingDate"].ToString() != "")
                {
                    Batch_Object.StratingDate = Convert.ToDateTime(Row["StartingDate"].ToString());
                }
                else
                {
                    Batch_Object.StratingDate = new DateTime(1, 1, 1);
                }
                if (Row["EndingDate"].ToString() != "")
                {
                    Batch_Object.EndingDate = Convert.ToDateTime(Row["EndingDate"].ToString());
                }
                else
                {
                    Batch_Object.EndingDate = new DateTime(1, 1, 1);
                }
                Batch_Object.CreationDate = Convert.ToDateTime(Row["CreationDate"].ToString());
                Batch_Object.Creator.ID = int.Parse(Row["EmpID"].ToString());
                Batch_Object.Creator.Name = Row["EmpName"].ToString();
                Batch_Object.ReceivingDate = Convert.ToDateTime(Row["ReceivingDate"].ToString());
                Batch_Object.DisplayID = Row["DisplayID"].ToString();
                Batch_Object.Type = Row["BatchType"].ToString();
            }
            return Batch_Object;
        }
    }
}