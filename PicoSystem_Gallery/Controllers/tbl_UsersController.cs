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
using PicoSystem_Gallery.Models;

namespace PicoSystem_Gallery.Controllers
{
    public class tbl_UsersController : ApiController
    {
        private mdl_Gallery db = new mdl_Gallery();

        // GET: api/tbl_Users
        public IEnumerable<tbl_Users> Gettbl_Users()
        {
            return db.tbl_Users.ToList();
        }

        // GET: api/tbl_Users/5
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Gettbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            return Ok(tbl_Users);
        }

        // PUT: api/tbl_Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttbl_Users(int id, tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != tbl_Users.Id)
            {
                return BadRequest();
            }

            db.Entry(tbl_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_UsersExists(id))
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

        // POST: api/tbl_Users
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Posttbl_Users(tbl_Users tbl_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Users.Add(tbl_Users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Users.Id }, tbl_Users);
        }

        // DELETE: api/tbl_Users/5
        [ResponseType(typeof(tbl_Users))]
        public IHttpActionResult Deletetbl_Users(int id)
        {
            tbl_Users tbl_Users = db.tbl_Users.Find(id);
            if (tbl_Users == null)
            {
                return NotFound();
            }

            db.tbl_Users.Remove(tbl_Users);
            db.SaveChanges();

            return Ok(tbl_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_UsersExists(int id)
        {
            return db.tbl_Users.Count(e => e.Id == id) > 0;
        }
    }
}