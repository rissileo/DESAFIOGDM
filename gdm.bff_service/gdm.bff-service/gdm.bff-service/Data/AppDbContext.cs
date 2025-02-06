using gdm.bff_service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace gdm.bff_service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SuiteType> SuiteTypes { get; set; }
        public DbSet<Motel> Motels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

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
