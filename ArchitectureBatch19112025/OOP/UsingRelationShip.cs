using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.OOP.UsingRelationShip
{
    public class Customer
    {
        public List<Address> Addresses { get; set; }
    }
    public class Supplier
    {
        public List<Address> Addresses { get; set; }

    }
    public class Patient
    {
        public List<Address> Addresses { get; set; }
        public List<Problem> Problems { get; set; }
    }
    public class Problem
    {
        public string type { get; set; }
        public string description { get; set; }
        private Patient _p = null;
        public Problem(Patient p)
        {
            _p = p;            
        }
    }
    public class Address
    {
        public string street1 { get; set; }
    }
}
