using gdm.bff_service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace gdm.bff_service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SuiteType> SuiteType { get; set; }
        public DbSet<Motel> Motel { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.SuiteType)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.SuiteTypeId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Motel)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MotelId);
        }
    }
}
