using gdm.bff_service.Data;
using gdm.bff_service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace gdm.bff_service.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        private readonly List<Reservation> _reservations;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "reservationList";

        public ReservationService(AppDbContext context, IMemoryCache cache)
        {
            _cache = cache;
            _context = context;

            _reservations = new List<Reservation>
            {
                new Reservation { Id = 1, Date = new DateTime(2025, 2, 1), ClientId = 1, SuiteTypeId = 1, MotelId = 1 },
                new Reservation { Id = 2, Date = new DateTime(2025, 3, 15), ClientId = 2, SuiteTypeId = 2, MotelId = 1 },
                new Reservation { Id = 3, Date = new DateTime(2025, 2, 10), ClientId = 1, SuiteTypeId = 1, MotelId = 2 },
                // Adicione mais reservas conforme necessário
            };
        }

        public IEnumerable<Reservation> GetReservationsByDate(DateTime startDate, DateTime endDate)
        {
            if (!_cache.TryGetValue(cacheKey, out List<Reservation> cachedReservations))
            {
                cachedReservations = _context.Reservation
                    .AsNoTracking()
                    .Where(r => r.Date >= startDate && r.Date <= endDate)
                    .ToList();
                _cache.Set(cacheKey, cachedReservations, TimeSpan.FromMinutes(5)); // Cache por 5 minutos
            }

            return cachedReservations.Where(r => r.Date >= startDate && r.Date <= endDate).ToList();
        }

        public decimal GetMonthlyRevenue(int year, int month)
        {
            var monthlyReservations = _context.Reservation
                .AsNoTracking()
                .Where(r => r.Date.Year == year && r.Date.Month == month)
                .Sum(r => r.Price);

            return monthlyReservations;
        }
    }
}
