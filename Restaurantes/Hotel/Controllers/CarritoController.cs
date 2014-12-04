using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel;

namespace Hotel.Controllers
{
    public class CarritoController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        // GET api/Carrito
        public IQueryable<Carritoe> GetCarritoes()
        {
            return db.Carritoes;
        }

        // GET api/Carrito/5
        [ResponseType(typeof(Carritoe))]
        public IHttpActionResult GetCarritoe(int id)
        {
            Carritoe carritoe = db.Carritoes.Find(id);
            if (carritoe == null)
            {
                return NotFound();
            }

            return Ok(carritoe);
        }

        // PUT api/Carrito/5
        public IHttpActionResult PutCarritoe(int id, Carritoe carritoe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carritoe.Carrito_Id)
            {
                return BadRequest();
            }

            db.Entry(carritoe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoeExists(id))
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

        // POST api/Carrito
        [ResponseType(typeof(Carritoe))]
        public IHttpActionResult PostCarritoe(Carritoe carritoe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carritoes.Add(carritoe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carritoe.Carrito_Id }, carritoe);
        }

        // DELETE api/Carrito/5
        [ResponseType(typeof(Carritoe))]
        public IHttpActionResult DeleteCarritoe(int id)
        {
            Carritoe carritoe = db.Carritoes.Find(id);
            if (carritoe == null)
            {
                return NotFound();
            }

            db.Carritoes.Remove(carritoe);
            db.SaveChanges();

            return Ok(carritoe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarritoeExists(int id)
        {
            return db.Carritoes.Count(e => e.Carrito_Id == id) > 0;
        }
    }
}