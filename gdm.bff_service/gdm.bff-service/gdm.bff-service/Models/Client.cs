﻿namespace gdm.bff_service.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Reservation> Reservations
        {
            get; set;
        }
    }
}
