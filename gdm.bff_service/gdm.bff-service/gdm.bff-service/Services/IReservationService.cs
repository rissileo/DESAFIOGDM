using gdm.bff_service.Models;

namespace gdm.bff_service.Services
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetReservationsByDate(DateTime startDate, DateTime endDate);
        decimal GetMonthlyRevenue(int year, int month);
    }
}
