using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restaurantes.Models;

namespace Restaurantes.Controllers
{
    public class OrdenController : ApiController
    {
        private readonly IRepository<Comida> comidaRepo;
        private readonly IRepository<Orden> ordenRepo;

        public OrdenController()
            : this(new MemoryRepository<Comida>(), new MemoryRepository<Orden>())
        { }

        public OrdenController(IRepository<Comida> ComidaRepo, IRepository<Orden> OrdenRepo)
        {
            comidaRepo = ComidaRepo;
            OrdenRepo = OrdenRepo;
        }

        public IEnumerable<Orden> Get()
        {
            return ordenRepo.Items;
        }
        public void Post(Orden orden)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState));

            if (!ValidateQuantities(orden))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Orden tiene cantidades erroneas!."));

            foreach (var articulo in orden.Articulos)
            {
                var articuloriginal = comidaRepo.Get(articulo.Id);
                articuloriginal.Cantidad -= articulo.CantidadSeleccionada;
                comidaRepo.Update(articuloriginal);
            }
            ordenRepo.Add(orden);
        }

        private bool ValidateQuantities(Orden orden)
        {
            foreach (var articulo in orden.Articulos)
            {
                var articuloOriginal = comidaRepo.Get(articulo.Id);
                if (articuloOriginal.Cantidad < articulo.CantidadSeleccionada) return false;
            }

            return true;
        }
    }
}
