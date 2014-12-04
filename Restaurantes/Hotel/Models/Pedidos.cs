using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Pedidos
    {
        [Key]
        public int Ped_Registro { get; set; }
        public int Ped_Id { get; set; }
        public string Ped_Nombre { get; set; }
        public decimal Ped_Total { get; set; }
        public string Ped_Completado { get; set; }
    }
}