using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Menu
    {
        [Key]
        public int Menu_Id { get; set; }
        public string Menu_Restaurante { get; set; }
        public string Menu_Tipo { get; set; }
        public string Menu_Nombre { get; set; }
        public string Menu_Descripcion { get; set; }
        public decimal Menu_Precio { get; set; }
    }
}