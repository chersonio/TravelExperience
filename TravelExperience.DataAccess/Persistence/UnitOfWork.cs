using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using TravelExperience.DataAccess.Core.Entities;
using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories;

namespace TravelExperience.DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public IBookingRepository Bookings { get; private set; }
        public IAccommodationRepository Accommodations { get; private set; }
        public IExperienceRepository Experiences { get; private set; }
        public IImagesRepository Images { get; private set; }
        public IUtilityRepository Utilities { get; private set; }
        //public IAccommodationUtilitiesRepository AccommodationUtilities { get; private set; }
        //public IAccommodationTypeRepository AccommodationTypes { get; set; }
        public IApplicationUserRepository Users { get; private set; }

        public ILocationRepository Locations { get; set; }
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Bookings = new BookingRepository(_context);
            Accommodations = new AccommodationRepository(_context);
            Experiences = new ExperienceRepository(_context);
            Images = new ImagesRepository(_context);
            Utilities = new UtilityRepository(_context);
            //AccommodationUtilities = new AccommodationUtilitiesRepository(_context);
            //AccommodationTypes = new AccommodationTypeRepository(_context);
            Users = new ApplicationUserRepository(_context);
            Locations = new LocationRepository(_context);
            InitializeDB();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    		
        //-- Insert into TravelExperience.[dbo].[AspNetRoles] (Id,   [Name])
        //-- VALUES
        //--('baebe278-930a-404e-8745-f80ee8fa18ce',	'Administrator'),
        //--('5d977c33-3a65-468e-8ae7-19db2ba63631',	'Host'),
        //--('98548089-2d72-42cb-bfe6-9709a09db96a',	'Traveler');
        
        /// <summary>
        /// The first time that we run the application, the table UserRoles will be empty, so it initializes the roles
        /// </summary>
        private void InitializeDB()
        {
            var somethin = _context.Roles.Select(x => x);
            if (_context.Roles.Select(x => x).Count() <= 0)
            {
                var Admin = new IdentityRole
                {
                    Id = "baebe278-930a-404e-8745-f80ee8fa18ce",
                    Name = "Administrator"
                };
                var Host = new IdentityRole
                {
                    Id = "5d977c33-3a65-468e-8ae7-19db2ba63631",
                    Name = "Host"
                };
                var Traveler = new IdentityRole
                {
                    Id = "98548089-2d72-42cb-bfe6-9709a09db96a",
                    Name = "Traveler"
                };
                _context.Roles.Add(Admin);
                _context.Roles.Add(Host);
                _context.Roles.Add(Traveler);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
