using Microsoft.EntityFrameworkCore;
using PlaneBookingWebApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneBookingWebApp.Infrastructure.Context
{
    public class PlaneBookingDbContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasIndex(x=>x.Name).IsUnique();
            modelBuilder.Entity<Plane>().HasIndex(x=>x.Code).IsUnique();
            modelBuilder.Entity<Flight>().HasIndex(x=>x.FlightCode).IsUnique();
        }

    }
}
