using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class HabitacionController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        // GET api/Habitacion
        public IQueryable<Habitaciones> GetHabitaciones()
        {
            return db.Habitaciones;
        }

        // GET api/Habitacion/5
        [ResponseType(typeof(Habitaciones))]
        public IHttpActionResult GetHabitaciones(short id)
        {
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            if (habitaciones == null)
            {
                return NotFound();
            }

            return Ok(habitaciones);
        }

        // PUT api/Habitacion/5
        public IHttpActionResult PutHabitaciones(short id, Habitaciones habitaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habitaciones.Hab_Numero)
            {
                return BadRequest();
            }

            db.Entry(habitaciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionesExists(id))
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

        // POST api/Habitacion
        [ResponseType(typeof(Habitaciones))]
        public IHttpActionResult PostHabitaciones(Habitaciones habitaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habitaciones.Add(habitaciones);
            try
            {

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var context = ((IObjectContextAdapter)db).ObjectContext;
                context.Refresh(RefreshMode.ClientWins, db);
                context.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = habitaciones.Hab_Numero }, habitaciones);
        }

        // DELETE api/Habitacion/5
        [ResponseType(typeof(Habitaciones))]
        public IHttpActionResult DeleteHabitaciones(short id)
        {
            Habitaciones habitaciones = db.Habitaciones.Find(id);
            if (habitaciones == null)
            {
                return NotFound();
            }

            db.Habitaciones.Remove(habitaciones);
            db.SaveChanges();

            return Ok(habitaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabitacionesExists(short id)
        {
            return db.Habitaciones.Count(e => e.Hab_Numero == id) > 0;
        }
    }
}