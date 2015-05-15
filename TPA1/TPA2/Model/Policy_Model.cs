using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA2.Model
{
    public struct Policy_Model
    {
        public int ID { get; set; }
        //public Holder_Model Holder = new Holder_Model();
       // public Insurance_Model Insurance = new Insurance_Model();
        public Holder_Model Holder;
        public Insurance_Model Insurance;
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public Decimal IBNR { get; set; }
        public Decimal Processed { get; set; }
        public Decimal UnProcessed { get; set; }
        public Decimal Premium { get; set; }
        public String Contract { get; set; }
        public int JustificationRange { get; set; }
        public int DeliveryRange { get; set; }
        public DateTime AddingDate { get; set; }
        //public Employee_Model Creator = new Employee_Model();
        public Employee_Model Creator;
    }
}