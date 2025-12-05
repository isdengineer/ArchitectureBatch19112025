using ArchitectureBatch19112025.DIandIOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DIandIOCSimpleFactory
{
    // i moved the object creation process from many places
    // to centralize place
    public static class FactorySupplier
    {
        private static Dictionary<int, Supplier> ContainerCollection = new Dictionary<int, Supplier>();
         static  FactorySupplier()
        {
            // dynamic reflection
            ContainerCollection.Add(0, new Supplier(new SeniorDiscount()));
            ContainerCollection.Add(1, new Supplier(new AmountLimit()));

        }
        public static Supplier Create(int i)
        {
            return ContainerCollection[i];

        }
    }
}
