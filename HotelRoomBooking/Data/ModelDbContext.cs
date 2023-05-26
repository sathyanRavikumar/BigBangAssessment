using HotelRoomBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelRoomBooking.Data
{
    public class ModelDbContext : DbContext
    {
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {

        }

        
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Resevation> resevations { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<User> users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
