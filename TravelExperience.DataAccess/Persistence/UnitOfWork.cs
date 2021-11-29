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
        public IAccommodationUtilitiesRepository AccommodationUtilities { get; private set; }
        public IApplicationUserRepository Users { get; private set; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Bookings = new BookingRepository(_context);
            Accommodations = new AccommodationRepository(_context);
            Experiences = new ExperienceRepository(_context);
            Images = new ImagesRepository(_context);
            Utilities = new UtilityRepository(_context);
            AccommodationUtilities = new AccommodationUtilitiesRepository(_context);
            Users = new ApplicationUserRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
