using System;
using System.Threading.Tasks;
using Ahoy.AspNetCore.Hospitality.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<Models.Hotel> Hotels { get; set; }
        public DbSet<Models.Facility> Facilities { get; set; }
        public DbSet<Models.HotelRating> HotelRatings { get; set; }
        public DbSet<Models.Reservation> Reservations { get; set; }
        public DbSet<Models.Room> Rooms { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Models.Facility>().ToTable("Facilitiy");
            modelBuilder.Entity<Models.HotelRating>().ToTable("HotelRating");
            modelBuilder.Entity<Models.Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Models.Room>().ToTable("Room");
        }
    }
}
