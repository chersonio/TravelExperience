using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExperience.ImportExportDB;

namespace ImportExportDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Import import = new Import(); // TODO

            Exporter exporter = new Exporter();
            exporter.Export();

            Console.ReadKey();
        }
    }
}
