namespace gdm.bff_service.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int SuiteTypeId { get; set; }
        public SuiteType SuiteType { get; set; }
        public int MotelId { get; set; }
        public Motel Motel { get; set; }
        public decimal Price { get; set; }
    }
}
