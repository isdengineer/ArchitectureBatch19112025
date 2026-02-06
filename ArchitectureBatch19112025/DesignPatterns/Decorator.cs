using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns.Decorator
{
    
    public interface ICustomer
    {
        int Id { get; set; }
        string CustomerType { get; set; }
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        void Validate();
    }

    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        public void Validate()
        {
            if (this.CustomerName.Length == 0)
            {
                throw new Exception("Name required");
            }
        }
    }

    public interface IValidation<T>
    {
        void Validate(T obj);
    }
    public class CustomerBasicValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            obj.Validate();
        }
    }
    public class ValidationLinker : IValidation<ICustomer>
    {
        private IValidation<ICustomer> nextvalidator = null;
        public ValidationLinker(IValidation<ICustomer> Ivalidation)
        {
            nextvalidator = Ivalidation;
        }

        public virtual void Validate(ICustomer obj)
        {
            nextvalidator.Validate(obj); ;
        }
    }

    public class PhoneNumberValidation : ValidationLinker
    {
        public PhoneNumberValidation(IValidation<ICustomer> Ivalidation) : 
                    base(Ivalidation)
        {
        }
        public override void Validate(ICustomer obj)
        {
            base.Validate(obj);
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number");
            }
        }
    }
    public class BillAmountNoZerovalidation : ValidationLinker
    {
        public BillAmountNoZerovalidation(IValidation<ICustomer> Ivalidation) : base(Ivalidation)
        {
        }

        public override void Validate(ICustomer obj)
        {
            base.Validate(obj);
            if (obj.BillAmount == 0)
            {
                throw new Exception("Bll amount negative");
            }
        }
    }
 }
