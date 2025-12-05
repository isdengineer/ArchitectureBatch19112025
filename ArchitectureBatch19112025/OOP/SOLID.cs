using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.OOP
{
    // SRP :- 1 class 1 thing at a time
    // OCP :- Open for extension closed for modification.
    // LSP :- LISKOV Sustition principle ( Wrong Abs)
    // ISP :- Interface Seegration Principle ( Uncessary exposed to client)
    // DI :-  Depedency Inversion
    public class EmergencyPatient
    {
        public int Gender { get; set; }
    }
    public class Patient
    {
        private string _name;

        public virtual string Name
        {
            get { return _name; }
            set {
                if (value.Length == 0)
                {
                    throw new Exception("Name is requred");
                }
                _name = value; 
            }
        }

        public string Address { get; set; }
        public decimal BillAmount { get; set; }
        public bool Save()
        {
            ICrudPatient y = null; // <-- 
            y.Save(this);
            return true;
        }
        public virtual decimal CalculateBill()
        {
            
            return BillAmount; // OCP
        }
    }
    public class Emr1 : Patient
    {
        private string _name;

        public override string Name
        {
            get { return _name; }
            set { throw new Exception("ddd"); }
        }

    }
    public class PatientKid : Patient
    {
        public override decimal CalculateBill()
        {
            return BillAmount - 100;
        }
    }
    public interface IReadPatient
    {
       
         List<Patient> Read();
    }
    public interface ICrudPatient : IReadPatient
    {
        void Save(Patient obj);
    }
    public class PatientDb : IReadPatient,ICrudPatient
    {
        public List<Patient> Read()
        {
            throw new NotImplementedException();
        }

        public void Save(Patient obj)
        {
            throw new NotImplementedException();
        }
    }

}
