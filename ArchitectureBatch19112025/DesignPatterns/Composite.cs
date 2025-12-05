using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns
{
    public  class Menu // whole
    {
        // sub menu is  parr of it
        public List<Menu> SubMenu { get; set; } // tree structure
        public string MenuName { get; set; }
        
        public virtual void Open()
        {

        }
    }
}
