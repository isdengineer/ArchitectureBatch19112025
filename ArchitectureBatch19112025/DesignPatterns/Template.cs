using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns
{
    public abstract class PageLifeCycle
    {

        public virtual void Init()
        {

        }
        public virtual void Load()
        {

        }
        public virtual void Render()
        {

        }
        public void Execute() // without changing the algorithm's structure
        {
            //Defines the skeleton of an algorithm in an operation
            Init();
            Load();
            Render();
        }
    }
    public class UICountry : PageLifeCycle
    {
        //Template Method lets subclasses redefine certain steps of an algorithm
        public override void Load()
        {
            // load countires
        }
    }
}
