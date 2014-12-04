using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Habitaciones
    {
        [Key]
        public short? Hab_Numero { get; set; }
        public string Hab_Nombre { get; set; }
        public string Hab_Apellido { get; set; }
        public string Hab_Rfc { get; set; }
    }
}