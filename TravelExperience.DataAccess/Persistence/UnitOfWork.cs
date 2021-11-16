using TravelExperience.DataAccess.Core.Interfaces;
using TravelExperience.DataAccess.Persistence.Repositories;

namespace TravelExperience.DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public IBookingRepository Bookings { get; private set; }
        public ITravelerRepository Travelers { get; private set; }

        public IAccommodationRepository Accommodations { get; private set; }

        public IExperienceRepository Experiences { get; private set; }

        public IHostRepository Hosts { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Bookings = new BookingRepository(_context);
            Travelers = new TravelerRepository(_context);
            Accommodations = new AccommodationRepository(_context);
            Experiences = new ExperienceRepository(_context);
            Hosts = new HostRepository(_context);
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
