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
using System.Configuration;

namespace ImportExportDB
{
    /// <summary>
    /// From default filepath and database, it saves all the tables of the database to the default .txt
    /// </summary>
    public class Exporter
    {
        #region Properties/Fields

        private readonly IUnitOfWork _unitOfWork;

        // Tables 
        private IEnumerable<Accommodation> accommodations { get; set; }
        private IEnumerable<Booking> bookings { get; set; }
        private IEnumerable<Location> locations { get; set; }
        private IEnumerable<Utility> utilities { get; set; }
        private IEnumerable<Transaction> transactions { get; set; }

        // Users and roles
        private IEnumerable<ApplicationUser> users { get; set; }
        private AppDBContext context { get; set; }
        private List<IdentityRole> roles { get; set; }
        private List<IdentityUserRole> userRoles { get; set; }
        private IEnumerable<Wallet> wallets { get; set; }

        private List<Dictionary<string, string>> sqlInsertQuery = new List<Dictionary<string, string>>();

        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // Constants
        const string FILEPATH = @"C:\TravelExperience\ImportExport\";
        const string FILETOSTORE = "ExportedDBTables.txt";
        const string DATABASE = "TravelExperienceTEST";
        
        #endregion

        public Exporter()
        {
            _unitOfWork = new UnitOfWork(new AppDBContext());
        }

        /// <summary>
        /// Exports database to a single txt file. Automatically saves it to a .txt
        /// The file is for internal purposes and not a tool to generally backup the full database");
        /// 1) You will see the use of database");
        /// 2) The insert statements for each table"); 
        /// 3) The values inserted coming from the latest exportation"); 
        /// 4) Enables Identity Inserts for primary keys when needed");
        /// </summary>
        public void Export()
        {
            Console.WriteLine("Started DB Exportation...");

            SetTables();
            StreamWriter streamWriter = new StreamWriter(FILEPATH + FILETOSTORE);

            streamWriter.WriteLine($"USE {DATABASE}");
            streamWriter.WriteLine();

            string table = "";

            streamWriter.WriteLine("-- This txt file is for internal purposes and not a tool to generally backup the full database");
            streamWriter.WriteLine("-- 1) You will see the use of database");
            streamWriter.WriteLine("-- 2) The insert statements for each table");
            streamWriter.WriteLine("-- 3) The values inserted coming from the latest exportation");
            streamWriter.WriteLine("-- 4) Enables Identity Inserts for primary keys when needed");
            streamWriter.WriteLine();

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

            table = "Transactions";
            if (transactions != null && transactions.Any())
            {
                GetValues(transactions);
                WriteTableToFile(streamWriter, table, true);
            }
            else
                Console.WriteLine(table + " empty. Skip and continue.");

            table = "Wallets";
            if (wallets != null && wallets.Any())
            {
                GetValues(wallets);
                WriteTableToFile(streamWriter, table, false);
            }
            else
                Console.WriteLine(table + " empty. Skip and continue.");
            

            //Close the file
            streamWriter.Close();

            Console.WriteLine("Closed file.");
            Console.WriteLine();
            Console.WriteLine("---Finished procedure. DB Exporting Successful!---");
        }
        /// <summary>
        /// Initializes entities from DBContext
        /// </summary>
        private void SetTables()
        {
            Console.WriteLine("Started setting tables...");

            accommodations = _unitOfWork.Accommodations.GetAll();
            bookings = _unitOfWork.Bookings.GetAll();
            locations = _unitOfWork.Locations.GetAll();
            utilities = _unitOfWork.Utilities.GetAll();

            users = _unitOfWork.Users.GetAll();
            context = new AppDBContext();
            roles = context.Roles.ToList();
            userRoles = users.Distinct().SelectMany(x => x.Roles).ToList();

            transactions = _unitOfWork.Transactions.GetAll().ToList();
            wallets = users.Select(x=> _unitOfWork.Users.GetWalletOfUserFromUserID(x.Id));
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
            try
            {
                streamWriter.WriteLine($"( {string.Join(", ", sqlInsertQuery.First().Keys.Select(x => "[" + x.ToString() + "]"))} )");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.Read();

                Console.WriteLine("--- Procedure failed --- ");
                return;
            }
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
                        getPropValue = (int)prop.GetValue(obj);
                    }
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        getName = prop.Name;
                        getPropValue = (bool)prop.GetValue(obj) ? "1" : "0"; // true in sql is stored as 1.
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