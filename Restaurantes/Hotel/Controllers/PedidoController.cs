using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class PedidoController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        // GET api/Pedido
        public IQueryable<Pedidos> GetPedidos()
        {
            return db.Pedidos;
        }

        // GET api/Pedido/#
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult GetPedidos(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        // PUT api/Pedido/5
        public IHttpActionResult PutPedidos(int id, Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidos.Ped_Registro)
            {
                return BadRequest();
            }

            db.Entry(pedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Pedido
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult PostPedidos(Pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(pedidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidos.Ped_Registro }, pedidos);
        }

        // DELETE api/Pedido/5
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult DeletePedidos(int id)
        {
            Pedidos pedidos = db.Pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.Pedidos.Remove(pedidos);
            db.SaveChanges();

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidosExists(int id)
        {
            return db.Pedidos.Count(e => e.Ped_Registro == id) > 0;
        }
    }
}