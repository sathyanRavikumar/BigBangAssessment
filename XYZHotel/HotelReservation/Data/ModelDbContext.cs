using HotelReservation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelReservation.Data
{
    public class ModelDbContext :DbContext
    {
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {
        }


        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Reservation> resevations { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<User> users { get; set; }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
