using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA2.Model
{
    public struct Holder_Model
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String CRNO { get; set; }
        public String CINO { get; set; }
        public String TaxesID { get; set; }
        public DateTime LicenceStartingDate { get; set; }
        public DateTime LicenceEndingDate { get; set; }
        public DateTime EstDate { get; set; }
        public DateTime SingingDate { get; set; }
        public String LicenceNo { get; set; }
        public String CEO { get; set; }
        public bool Active { get; set; }
        public DateTime AddingDate { get; set; }
        //public Employee_Model Creator = new Employee_Model();
        public Employee_Model Creator;
    }
}