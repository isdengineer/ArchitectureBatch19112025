using ArchitectureBatch19112025.DIandIOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns.FactoryMethod
{
    public class Customer
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public decimal Amount { get; set; }
        public int Age { get; set; }
        public string Delivery { get; set; }
        public IDelivery delvdis { get; set; }
        public IDiscountAge agedis { get; set; }
        public IAmount amtdis { get; set; }

        public Customer(IDelivery _dev, 
                        IDiscountAge _age , 
                        IAmount _amt)
        {
                delvdis = _dev;
                agedis = _age;
                amtdis = _amt;
        }
        public decimal Discount()
        {
            return Amount - (delvdis.Discount() + 
                             agedis.Discount()+
                             amtdis.Discount());
        }
    }
    public interface IDelivery
    {
        decimal Discount();
    }
    public class Courier : IDelivery
    {
        public decimal Discount()
        {
            // look up
            // lot of logic
            return 10;
        }
    }
    public class SelfDelivery : IDelivery
    {
        public decimal Discount()
        {
            // look up
            // lot of logic
            return 20;
        }
    }
    
    public interface IDiscountAge
    {
        decimal Discount();
    }
    public class SeniorCitizen : IDiscountAge
    {
        public decimal Discount()
        {
            throw new NotImplementedException();
        }
    }
    public class AgeLessThan40 : IDiscountAge
    {
        public decimal Discount()
        {
            return 0;
        }
    }
    public class Kids : IDiscountAge
    {
        public decimal Discount()
        {
            throw new NotImplementedException();
        }
    }
    public interface IAmount
    {
        decimal Discount();
    }
    public class AmountOver10k : IAmount
    {
        public decimal Discount()
        {
            return 0;
        }
    }
    public class NoDiscountAmount : IAmount
    {
        public decimal Discount()
        {
            return 0;
        }
    }
    public static class SimpleFactory
    {
        public static Customer Create(int i)
        {
            IFactoryCustomer f = new FactoryCustomer2();
            if (i == 0)
            {
                 f = new FactoryCustomer2();
                
            }
            else
            {
                 f = new FactoryCustomer3();
                
            }
            return f.Create(); 
        }
    }
    
    public interface IFactoryCustomer
    {
        //Define an interface for creating an object
        Customer Create();
        IAmount CreateAmount();
        IDelivery CreateDelivery();
        IDiscountAge CreateAgeDiscount();
    }
    public  class FactoryCustomer : IFactoryCustomer // MUS
    {
        public Customer Create() // method
        {
            return new Customer(CreateDelivery() , 
                            CreateAgeDiscount() , 
                            CreateAmount());
        }

        public virtual IDiscountAge CreateAgeDiscount()
        {
            return new AgeLessThan40();
        }

        public virtual IAmount CreateAmount()
        {
            return new AmountOver10k();
        }

        public virtual IDelivery CreateDelivery()
        {
            return new Courier(); ;
        }

        
    }
    // but let subclasses decide which class to instantiate
    public class FactoryCustomer2 : FactoryCustomer
    {
        public override IDelivery CreateDelivery()
        {
            return new SelfDelivery();
        }
    }
    public class FactoryCustomer3 : FactoryCustomer
    {
        public override IDiscountAge CreateAgeDiscount()
        {

            return new SeniorCitizen();
        }
    }
}
