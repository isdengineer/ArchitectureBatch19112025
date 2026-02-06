using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns.Singleton
{
    public  class Country
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
    }
    // Singleton = Static + Thread safety + lazy Loading +
    //services.AddSingleton<Global>(); Vs Singleton pattern
    // servuces.AddSingleton<Country>(){
    //  Global._instance.Country
    //  }
    public class Global
    {
        private static Global _instance = null; // part whole relationship
        private  List<Country> _Countries;
        private  List<string> _States;
        private Global()
        {
            
        }
        public static Global getInstance()
        {
            if (_instance == null) // lazy loading // 1
            {
                lock (_instance)
                {
                    if (_instance == null) // Double null check null
                    {
                        _instance = new Global();
                    }
                }
            }
            return _instance;
        }

        public  IEnumerable<Country> getCountries()
        {
            lock (_Countries) // one thread can enter...
            {
                if (_Countries == null) // Lazy Loading
                {
                    _Countries = new List<Country>();
                    _Countries.Add(new Country() { Name = "India" }); // code
                }
            }
            return _Countries.ToList(); // copy
        }
        public  void Refresh()
        {
            lock (_Countries) // one thread can enter...
            {
                _Countries = new List<Country>();
                _Countries.Add(new Country() { Name = "India" }); // code
            }
        }
       
    }
    public static class BreakSingleton
    {
        public static void CreateInstance()
        {
            var type = typeof(Global);
            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            var newInstance = (Global)constructor.Invoke(null);
        }
    }
}
