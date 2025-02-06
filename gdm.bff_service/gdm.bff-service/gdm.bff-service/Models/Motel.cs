namespace gdm.bff_service.Models
{
    public class Motel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Reservation> Reservations
        {
            get; set;
        }
    }
}
