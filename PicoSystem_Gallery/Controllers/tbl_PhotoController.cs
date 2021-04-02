using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using PicoSystem_Gallery.Models;

namespace PicoSystem_Gallery.Controllers
{
    public class tbl_PhotoController : ApiController
    {
        private mdl_Gallery db = new mdl_Gallery();

        // GET: api/tbl_Photo
        [HttpGet]
        public IQueryable<tbl_Photo> Gettbl_Photos()
        {
            return db.tbl_Photos;
        }

        // GET: api/tbl_Photo/5
        [ResponseType(typeof(tbl_Photo))]
        [HttpGet]
        public IQueryable<tbl_Photo> Gettbl_Photo(int id)
        {
            tbl_Users tb = db.tbl_Users.Find(id);
            if (tb == null)
            {
                return null;
            }
            IQueryable<tbl_Photo> tbl_Photos = db.tbl_Photos.Where(a=>a.UserId.Equals(id)).ToArray().AsQueryable();
            if (tbl_Photos == null)
            {
                return null;
            }           
            return tbl_Photos;
        }

        // POST: api/tbl_Photo/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult Posttbl_Photo(int id)
        {
            var file = HttpContext.Current.Request.Files["UploadedImage"];
            string Des= HttpContext.Current.Request["Des"];
            if (file == null)
            {
                return NotFound();
            }
            tbl_Users tb = db.tbl_Users.Find(id);
            if (tb == null)
            {
                return NotFound();
            }
            string fname = "";
            if (file != null)
            {
                string newFilenameUrl = string.Empty;
                string filename = Path.GetFileName(file.FileName);
                string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty) +
                                         Path.GetExtension(filename);
                newFilenameUrl = "/Upload/" + newFilename;
                string physicalFilename = System.Web.Hosting.HostingEnvironment.MapPath(newFilenameUrl);
                file.SaveAs(physicalFilename);
                fname = newFilenameUrl;
            }
            if (fname=="")
            {
                return NotFound();
            }
            tbl_Photo tp = new tbl_Photo();
            tp.PhotoPath = fname;
            tp.tarikhUpload = DateTime.Now;
            tp.UserId = tb.Id;
            tp.UserName = tb.Name + " " + tb.Family;
            tp.Description= Des;
            db.tbl_Photos.Add(tp);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/tbl_Photo/5
        [HttpDelete]
        [ResponseType(typeof(tbl_Photo))]
        public IHttpActionResult Deletetbl_Photo(int id)
        {
            tbl_Photo tbl_Photo = db.tbl_Photos.Find(id);
            if (tbl_Photo == null)
            {
                return NotFound();
            }

            db.tbl_Photos.Remove(tbl_Photo);
            db.SaveChanges();
            if (System.IO.File.Exists(HostingEnvironment.MapPath(tbl_Photo.PhotoPath)))
            {
                System.IO.File.Delete(HostingEnvironment.MapPath(tbl_Photo.PhotoPath));
            }
            return Ok(tbl_Photo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_PhotoExists(int id)
        {
            return db.tbl_Photos.Count(e => e.Id == id) > 0;
        }
    }
}