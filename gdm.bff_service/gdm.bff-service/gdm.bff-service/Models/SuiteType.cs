namespace gdm.bff_service.Models
{
    public class SuiteType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
