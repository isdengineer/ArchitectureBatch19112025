using ArchitectureBatch19112025.DesignPatterns;
using ArchitectureBatch19112025.DesignPatterns.Adapter;
using ArchitectureBatch19112025.DesignPatterns.FactoryMethod;
using ArchitectureBatch19112025.DIandIOC;
using ArchitectureBatch19112025.DIandIOCSimpleFactory;
using ArchitectureBatch19112025.OOP;

namespace ArchitectureBatch19112025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var cust = SimpleFactory.Create(1);
            cust.Discount();
        }
        static void SomeMethod()
        {
            Console.WriteLine("Some method");

        }
    }
}
