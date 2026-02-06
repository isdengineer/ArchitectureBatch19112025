using ArchitectureBatch19112025.DesignPatterns;
using ArchitectureBatch19112025.DesignPatterns.Decorator;
using ArchitectureBatch19112025.DesignPatterns.ProtoType;
using ArchitectureBatch19112025.DesignPatterns.Singleton;


namespace ArchitectureBatch19112025
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var s = new Supplier();
            s.Name  = "Test";
            s.Address = new Address() { Street1 = "xyz1" };
            s.SaveState();
            s.Name = "Text1";
            s.Revert();

        }
        static void SomeMethod()
        {
            Console.WriteLine("Some method");

        }
    }
}
