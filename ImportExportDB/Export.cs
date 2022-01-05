using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportExportDB
{
    public class Export
    {
        private readonly IUnitOfWork _unitOfWork;

        // Tables 
        IEnumerable<Accommodation> accommodations { get; set; }
        IEnumerable<Booking> bookings { get; set; }
        IEnumerable<Image> images { get; set; }
        IEnumerable<Location> locations { get; set; }
        IEnumerable<Utility> utilities { get; set; }

        // Users and roles
        IEnumerable<ApplicationUser> users { get; set; }
        AppDBContext context { get; set; }
        List<IdentityRole> roles { get; set; }
        List<IdentityUserRole> userRoles { get; set; }

        List<Dictionary<string, string>> sqlInsertQuery = new List<Dictionary<string, string>>();
        //Dictionary<string, bool> EntityInsertValue;

        const string FILEPATH = @"C:\TravelExperience\ImportExport\";
        const string FILETOSTORE = "test.txt";
        const string SERVERNAME = "TravelExperienceTEST";

        /// <summary>
        /// Exports database to a single txt file. Automatically saves it to a test.txt
        /// </summary>
        public Export()
        {
            Console.WriteLine("Started DB Exportation...");
            _unitOfWork = new UnitOfWork(new AppDBContext());

            SetTables();
            StreamWriter streamWriter = new StreamWriter(FILEPATH + FILETOSTORE);

            streamWriter.WriteLine($"USE {SERVERNAME}");
            streamWriter.WriteLine();

            string table = "";

            //Pass the filepath and filename to the StreamWriter Constructor
            table = "AspNetUsers";
            GetValues(users);
            WriteTableToFile(streamWriter, table, false);

            table = "AspNetRoles";
            GetValues(roles);
            WriteTableToFile(streamWriter, table, false);

            table = "AspNetUserRoles";
            GetValues(userRoles);
            WriteTableToFile(streamWriter, table, false);

            table = "Locations";
            GetValues(locations);
            WriteTableToFile(streamWriter, table, true);

            table = "Accommodations";
            GetValues(accommodations);
            WriteTableToFile(streamWriter, table, true);

            table = "Bookings";
            GetValues(bookings);
            WriteTableToFile(streamWriter, table, true);

            table = "Utilities";
            GetValues(utilities);
            WriteTableToFile(streamWriter, table, true);

            //table = "Images";
            //GetValues(images);
            //WriteTableToFile(streamWriter, table, true);

            //Close the file
            streamWriter.Close();

            Console.WriteLine("Closed file.");

            Console.WriteLine("Finished procedure. DB Exporting Successful.");
        }

        private void SetTables()
        {
            Console.WriteLine("Started setting tables...");

            accommodations = _unitOfWork.Accommodations.GetAll();
            bookings = _unitOfWork.Bookings.GetAll();
            images = accommodations.SelectMany(x => x.Images).Distinct();
            locations = _unitOfWork.Locations.GetAll();
            utilities = _unitOfWork.Utilities.GetAll();

            users = _unitOfWork.Users.GetAll().Distinct();
            context = new AppDBContext();
            roles = context.Roles.ToList();
            userRoles = users.Distinct().SelectMany(x => x.Roles).ToList();
        }

        private void GetValues<T>(IEnumerable<T> entity)
        {
            Console.WriteLine("Getting values...");

            sqlInsertQuery = new List<Dictionary<string, string>>();

            foreach (var ent in entity)
            {
                sqlInsertQuery.Add(GetPropertyValues<T>(ent));
            }
        }

        private void WriteTableToFile(StreamWriter streamWriter, string table, bool activatePrimaryKeyInsertion)
        {
            Console.WriteLine($"Writing to file table: {table}");

            // sets this to ON because in most of our tables it is locked to set the primary key
            if (activatePrimaryKeyInsertion)
                streamWriter.WriteLine($"SET IDENTITY_INSERT [{table}] ON;");

            streamWriter.WriteLine($"INSERT INTO [{table}] ");
            streamWriter.WriteLine($"( {string.Join(", ", sqlInsertQuery.First().Keys.Select(x => "[" + x.ToString() + "]"))} )");
            streamWriter.WriteLine("VALUES");

            var counter = 0;
            foreach (var line in sqlInsertQuery)
            {
                // creates the row represantation to string
                var row = $"( {string.Join(", \t", line.Values.Select(x => x == "''" ? "'NULL'" : x).ToList())} ";
                // finishes line with ), if there are more rows,
                // or finishes with ); if it is the last row.
                if (counter < sqlInsertQuery.Count() - 1)
                {
                    row += " ),";
                    counter++;
                }
                else
                    row += " );";

                streamWriter.WriteLine(row);
            }

            if (activatePrimaryKeyInsertion)
                streamWriter.WriteLine($"SET IDENTITY_INSERT [{table}] OFF;");

            streamWriter.WriteLine(); // extra line to separate

            Console.WriteLine($"Finished writing to file table: {table}.");
        }

        // Na diwksw ta NotMapped
        private static Dictionary<string, string> GetPropertyValues<T>(T obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] props = objType.GetProperties();

            Dictionary<string, string> Row = new Dictionary<string, string>();

            foreach (var prop in props)
            {
                string getName = "";
                string getPropType = prop.PropertyType.Name;
                object getPropValue = "";
                var skipOnNotMappedAttribute = prop.GetCustomAttribute(typeof(NotMappedAttribute));
                if (skipOnNotMappedAttribute != null)
                {
                    continue;
                }
                if (prop.PropertyType == typeof(DateTime) ||
                   prop.PropertyType == typeof(string))
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        getName = prop.Name;
                        getPropValue = prop.GetValue(obj);
                    }
                }
                else if (prop.PropertyType.BaseType == typeof(Enum))
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        getName = prop.Name;
                        getPropValue = (int)prop.GetValue(obj); // how to make it from the correct enum to its equivalent int?

                        //Convert.ChangeType(prop, getPropValue);

                    }
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        getName = prop.Name;
                        getPropValue = (bool)prop.GetValue(obj) ? "1" : "0"; // if it is true in sql is stored as 1.
                    }
                }
                else if (prop.PropertyType == typeof(int) ||
                    prop.PropertyType == typeof(double) ||
                    prop.PropertyType == typeof(float) ||
                    prop.PropertyType == typeof(decimal) ||
                    prop.Name.ToLower().Contains("id"))
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        getName = prop.Name;
                        getPropValue = prop.GetValue(obj);
                    }
                }

                if (getPropValue != null && !string.IsNullOrWhiteSpace(getPropValue.ToString()))
                {
                    Row.Add(getName, $"'{getPropValue.ToString().Replace("'", "`")}'");
                }
            }
            return Row;
        }
    }
}