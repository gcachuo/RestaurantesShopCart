using System.Collections.Generic;
using System.Data.Entity;
using Hotel.Models;

namespace Hotel
{
    public class HotelDBInitializer 
    {
        protected void Seed(HotelDBContext context)
        {
            var pedido = new List<Pedidos> {
            new Pedidos
            {
                //Ped_Comentario = "Comment", 
                //Ped_Descripcion = "Descripcion",
                Ped_Id = 1,Ped_Nombre = "Nombre",
                //Ped_Registro = 1,Ped_Tipo = "Tipo",
                Ped_Total = 10
            
            }
        };

            //pedido.ForEach(c => context.Pedidos.Add(c));
            //context.SaveChanges();
        }
    }
}