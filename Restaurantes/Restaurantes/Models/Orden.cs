using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantes.Models
{
    public class Orden:Entity
    {
        public string CustomerName { get; set; }
        public double OrderTotal { get; set; }
        public bool Approved { get; set; }

        public virtual ICollection<Comida> Articulos { get; set; }
    }
}