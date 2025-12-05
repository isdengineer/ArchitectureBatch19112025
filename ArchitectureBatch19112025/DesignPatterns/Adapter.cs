using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureBatch19112025.DesignPatterns.Adapter
{
    public interface IExport
    {
        void Export();
    }
    public class WordExport : IExport
    {
        public void Export()
        {
            Console.WriteLine("Code of word");
        }
    }
    public class ExcelExport : IExport
    {
        public void Export()
        {
            Console.WriteLine("Code of Excel");
        }
    }
    
    public class PdfExport
    {
        public void Save()
        {
            Console.WriteLine("Third pary PDF component");
        }
    }

    public class PdfAdapter : PdfExport, IExport
    {
        public void Export()
        {
            this.Save();
        }
    }

}
