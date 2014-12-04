using System.Data.Entity;
using System.Data.Linq;

namespace Hotel
{
    public class CarritoContext : DataContext
    {
        public CarritoContext(string p):base(p){ }
        public Table<Carritoe> Carrito { get; set; }
        
    }
}