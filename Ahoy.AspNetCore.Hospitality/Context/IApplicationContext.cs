using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ahoy.AspNetCore.Hospitality.Context
{
    public interface IApplicationContext
    {

        public DbSet<Models.Hotel> Hotels { get; set; }
        public DbSet<Models.Facility> Facilities { get; set; }
        public DbSet<Models.HotelRating> HotelRatings { get; set; }
        public DbSet<Models.Reservation> Reservations { get; set; }
        public DbSet<Models.Room> Rooms { get; set; }

        Task<int> SaveChangesAsync();
    }
}
