using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns.ProtoType
{
    public class Supplier : ICloneable
    {
        private Supplier _Copy = null;
        public string Name { get; set; }
        public string Description { get; set; }

        public Address Address { get; set; }
        public void Revert()
        {
            //this = _Copy.Clone();
            this.Name = _Copy.Name;
            this.Address.Street1 = _Copy.Address.Street1;
        }
         public void SaveState()
        {
            _Copy = new Supplier();
            _Copy = (Supplier) Clone();
        }
        public Object Clone()
        {
            var suppli = new Supplier();
            suppli = (Supplier) this.MemberwiseClone();
            suppli.Address = (Address) this.Address.Clone();
            return suppli;
        }
    }
    public class Address : ICloneable
    {
        public string Street1 { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
