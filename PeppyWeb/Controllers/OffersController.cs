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
    public class OffersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Offers
        //returns all objects in the database in descending order
        public IEnumerable<Offer> GetOffers()
        {
            return db.Offers.OrderByDescending( o => o.Id);
        }

       
        // POST: api/Offers
        [ResponseType(typeof(Offer))]
        public IHttpActionResult PostOffer(Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var stream = new MemoryStream(offer.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = string.Format("{0}.jpg", guid);
                var folder = "~\\Content\\OfferData";
                var fullpath = string.Format("{0}\\{1}", folder, file);
                var response = Filehelpers.UploadPhoto(stream, folder, file);
              
                var Data = new Offer
                {
                    Description = offer.Description,
                    ImagePath = fullpath,
                    ExpiryDate = offer.ExpiryDate,
                    IsAvailable = offer.IsAvailable,
                    Title = offer.Title
                };
                db.Offers.Add(Data);
                db.SaveChanges();
                return Ok(Data);
            }

        }

        // DELETE: api/Offers/5
        //it deletes the object based on a specific Id
        [ResponseType(typeof(Offer))]
        public IHttpActionResult DeleteOffer(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return NotFound();
            }

            db.Offers.Remove(offer);
            db.SaveChanges();

            return Ok(offer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfferExists(int id)
        {
            return db.Offers.Count(e => e.Id == id) > 0;
        }
    }
}