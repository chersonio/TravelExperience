using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence;

namespace TravelExperience.ImportExportDB
{
    public class Import
    {
        private readonly AppDBContext _context;

        public Import()
        {
            _context = new AppDBContext();

            Reader();
        }

        const string FILENAME = @"C:\TravelExperience\ImportExport\test.txt";
        const string CONNECTIONSTRING = "TravelExperience";
        const string TARGETDATABSE = "TDJ-ESTABRITOS";

        private void Reader()
        {
            StreamReader reader = new StreamReader(FILENAME);

            string line = "";
            string category = "";
            string pattern = @"(?'name'.*)\s+(?'price'\d+)";

            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.Length > 0)
                {
                    if (line.StartsWith("#"))
                    {
                        category = line.Substring(1);
                    }
                    else
                    {
                        Match match = Regex.Match(line, pattern);
                        string name = match.Groups["name"].Value.Trim();
                        string price = match.Groups["price"].Value.Trim();

                        Console.WriteLine("category : '{0}', name : '{1}', price : '{2}'", category, name, price);

                    }
                }
            }
        }

    }
}
