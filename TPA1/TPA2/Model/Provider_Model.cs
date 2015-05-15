using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA2.Model
{
    public struct Provider_Model
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String CRNO { get; set; }
        public String Type { get; set; }
        public String Contract { get; set; }
        public bool MDInsurance { get; set; }
        public DateTime ContractStartingDate { get; set; }
        public DateTime ContractEndingDate { get; set; }
        public DateTime LicenceStartingDate { get; set; }
        public DateTime LicenceEndingDate { get; set; }
        public String LicenceNo { get; set; }
        public String TaxesID { get; set; }
        public bool Active { get; set; }
        public String PD { get; set; }
        public String IMCG { get; set; }
        public DateTime AddingDate { get; set; }
        //public Employee_Model Creator = new Employee_Model();
        public Employee_Model Creator;
    }
}