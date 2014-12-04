namespace Restaurantes.Models
{
    public class Comida:Entity
    {
        public string Nombre { get; set; }
        public string Restaurant { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public int CantidadSeleccionada { get; set; }
        public string Categoria { get; set; }
    }
}