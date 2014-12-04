using System.Data.Entity;
using Hotel.Models;

namespace Hotel
{
    public class HotelDBContext : DbContext
    {
       
        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Carritoe> Carritoes { get; set; }

        public DbSet<Habitaciones> Habitaciones { get; set; }

    }
}