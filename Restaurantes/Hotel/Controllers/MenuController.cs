using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class MenuController : ApiController
    {
        private HotelDBContext db = new HotelDBContext();

        public MenuController()
        {


        }
        // GET api/Menu
        public IQueryable<Menu> GetMenu()
        {
            return db.Menu;
        }


        // GET api/Menu/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(int id)
        {

            Menu menu = db.Menu.Find(id);
            using (
                var context =
                    new CarritoDataContext("Data Source=MEMO-HP;Initial Catalog=Rest_Hotel;Integrated Security=True"))
            {
                var carro = new Carritoe()
                {
                    Carrito_Id = hab.Hab_Numero,
                    Carrito_Descripcion = menu.Menu_Descripcion,
                    Carrito_Nombre = menu.Menu_Nombre,
                    Carrito_Precio = menu.Menu_Precio,
                    Carrito_Restaurante = menu.Menu_Restaurante,
                    Carrito_Tipo = menu.Menu_Tipo
                };

                context.Carritoes.InsertOnSubmit(carro);
                context.SubmitChanges();
            }


            return Ok(menu);
        }
        static Habitaciones hab = new Habitaciones();
        // PUT api/Menu/5
        public IHttpActionResult PutMenu(int id)
        {

            hab.Hab_Numero = (short)id;
            return Ok(id);
        }

        // POST api/Menu
        [ResponseType(typeof(Pedidos))]
        public IHttpActionResult PostMenu(Pedidos menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedidos.Add(menu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menu.Ped_Registro }, menu);
        }

        // DELETE api/Menu/5
        [ResponseType(typeof(Carritoe))]
        public IHttpActionResult DeleteMenu(int id)
        {
            using (
                var context =
                    new CarritoDataContext("Data Source=MEMO-HP;Initial Catalog=Rest_Hotel;Integrated Security=True"))
            {
                foreach (var carro in context.Carritoes.Where(carro => carro.Carrito_Id == id))
                {
                    context.Carritoes.DeleteOnSubmit(carro);
                }

                context.SubmitChanges();
            }

            return Ok(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menu.Count(e => e.Menu_Id == id) > 0;
        }
    }
}