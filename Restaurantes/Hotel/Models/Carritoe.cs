using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Carritoe:CarritoContext
    {
        public Carritoe(string p, int? carritoId, string carritoRestaurante, string carritoTipo, string carritoNombre, string carritoDescripcion, decimal? carritoPrecio) : base(p)
        {
            Carrito_Id = carritoId;
            Carrito_Restaurante = carritoRestaurante;
            Carrito_Tipo = carritoTipo;
            Carrito_Nombre = carritoNombre;
            Carrito_Descripcion = carritoDescripcion;
            Carrito_Precio = carritoPrecio;
        }

        [Key] public int? Carrito_Id { get; set; }

        public string Carrito_Restaurante { get; set; }

        public string Carrito_Tipo { get; set; }

        public string Carrito_Nombre { get; set; }

        public string Carrito_Descripcion { get; set; }

        public decimal? Carrito_Precio { get; set; }
		
    }
}