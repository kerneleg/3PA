using System;

namespace TPA2.Model
{
    public struct Batch_Model
    {
        public int ID { get; set; }
        //public Provider_Model Provider = new Provider_Model();
        public Provider_Model Provider;
        //public Policy_Model Policy = new Policy_Model();
        public Policy_Model Policy;
        public DateTime StratingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public DateTime CreationDate { get; set; }
        //public Employee_Model Creator = new Employee_Model();
        public Employee_Model Creator;
        public DateTime ReceivingDate { get; set; }
        public String DisplayID { get; set; }
        public String Type { get; set; }
    }
}