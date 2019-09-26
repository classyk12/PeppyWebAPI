using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PeppyWeb.Helpers;
using PeppyWeb.Models;

namespace PeppyWeb.Controllers
{
    [Authorize]
    public class CleanersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cleaners
        public IEnumerable<Cleaner> GetCleaners()
        {
            return db.Cleaners.OrderByDescending( c=> c.Id );
        }


        //gets all cleaners based on user location input
        public IEnumerable<Cleaner> GetCleaners(string location)
        {
            var request = db.Cleaners.Where(c => c.Location == location);
            if (request == null)
            {
                return null;
            }
            else
            {
                return request;
            }
        }


        // POST: api/Cleaners
        [ResponseType(typeof(Cleaner))]
        public IHttpActionResult PostCleaner(Cleaner cleaner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var stream = new MemoryStream(cleaner.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = string.Format("{0}.jpg", guid);
                var folder = "~\\Content\\CleanerData";
                var fullpath = string.Format("{0}\\{1}", folder, file);
                var response = Filehelpers.UploadPhoto(stream, folder, file);

                var data = new Cleaner
                {
                    Name = cleaner.Name,
                    Location = cleaner.Location,
                    PhoneNumber = cleaner.PhoneNumber,
                    IsAvailable = cleaner.IsAvailable,
                    ImagePath = fullpath
                };

          

            db.Cleaners.Add(data);
            db.SaveChanges();
            return Ok();
            }
        }

        // DELETE: api/Cleaners/5
        [ResponseType(typeof(Cleaner))]
        public IHttpActionResult DeleteCleaner(int id)
        {
            Cleaner cleaner = db.Cleaners.Find(id);
            if (cleaner == null)
            {
                return NotFound();
            }

            db.Cleaners.Remove(cleaner);
            db.SaveChanges();

            return Ok(cleaner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CleanerExists(int id)
        {
            return db.Cleaners.Count(e => e.Id == id) > 0;
        }
    }
}