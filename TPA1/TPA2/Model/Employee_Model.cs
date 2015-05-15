using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPA2.Model
{
    public struct Employee_Model
    {
        public int ID { get; set; }
        public String Name { get; set; }
        //public Titles_Model Title = new Titles_Model();
        public List<Titles_Model> Titles;
        public bool Gender { get; set; }
        public String Email { get; set; }
        public String MaritialStatus { get; set; }
        public DateTime HireDate { get; set; }
        public int VacationDays { get; set; }
        public int SickLeave { get; set; }
        public DateTime BirthDate { get; set; }
        public String Nationality { get; set; }
        public bool Active { get; set; }
        public DateTime AddingDate { get; set; }
        //public Employee_Model Creator = new Employee_Model();
        //public Employee_Model Creator;
    }
}