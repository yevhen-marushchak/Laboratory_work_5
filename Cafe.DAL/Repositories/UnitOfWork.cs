using Cafe.DAL.Entities;
using System.Threading.Tasks;
using System;

namespace Cafe.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly CafeDbContext _context;
        private GenericRepository<Activity> _activityRepository;
        private GenericRepository<Room> _roomRepository;
        private GenericRepository<Reservation> _reservationRepository;

        public UnitOfWork(CafeDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Activity> ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository = new GenericRepository<Activity>(_context);
                }
                return _activityRepository;
            }
        }

        public GenericRepository<Room> RoomRepository
        {
            get
            {
                if (_roomRepository == null)
                {
                    _roomRepository = new GenericRepository<Room>(_context);
                }
                return _roomRepository;
            }
        }

        public GenericRepository<Reservation> ReservationRepository
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new GenericRepository<Reservation>(_context);
                }
                return _reservationRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}