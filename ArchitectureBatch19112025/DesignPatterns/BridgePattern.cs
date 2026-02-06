using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns
{
    public interface IEmployee
    {
        string Name { get; set; }
        string Code { get; set; }
        decimal CalculateSalary(ISalaryCalculation e);
    }
    public interface ISalaryCalculation
    {
        decimal CalculateSalary(IEmployee e);
    }
    public class SalaryCalculationLevel1 : ISalaryCalculation
    {
        public decimal CalculateSalary(IEmployee e)
        {
            // 1000
            return 1000;
        }
    }
    public class Manager : IEmployee
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Code { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal CalculateSalary(ISalaryCalculation e)
        {
            return e.CalculateSalary(this);
        }
    }
}
