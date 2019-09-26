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
using PeppyWeb.Models;

namespace PeppyWeb.Controllers
{
    [Authorize]
    public class BookingsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Bookings
        public IEnumerable<Booking> GetBookings()
        {
            return db.Bookings.OrderByDescending(b => b.BookingId);
        }


        //to check how many bookings a cleaner have done
        public string GetBooking(int cleanerId)
        {
            var data = db.Bookings.Where(b => b.CleanerId == cleanerId).Count().ToString();
            return data;
        }

        //gets all completed bookings in the Booking Table
        [Route("api/DoneBooking")]
      public IEnumerable<Booking> GetDoneBookings(string UserId)
        {
            var data = db.Bookings.Where(b => b.UserId == UserId).Where( b => b.IsCompleted == true);            
            return data;
        }

        //gets all uncompleted bookings in the Booking Table
        [Route("api/PendingBooking")]
        public IEnumerable<Booking> GetPendingBookings(string UserId)
        {
            var data = db.Bookings.Where(b => b.UserId == UserId).Where(b => b.IsCompleted == false);
            return data;
        }


        //to check the total number of bookings for a user
        public string GetUserCount(string user)
        {
            var data = db.Bookings.Where(b => b.UserId == user).Count().ToString();
            return data;
        }

        //checks the latest booking date of a user
        public Booking GetBookings(string userkey)
        {
            var data1 = db.Bookings.Where(b => b.UserId == userkey).OrderByDescending(b=>b.BookingId).FirstOrDefault();
            return data1;                                                  
        }

        //checks the total number of cleaners hired by a user without repitition
        public string GetCleanerCount(string identity)
        {
            var data = db.Bookings.Where(b => b.UserId == identity).Select(c => c.CleanerId).Distinct().Count().ToString();
            //var data = db.Bookings.Select(b => b.CleanerId).Distinct().Count().ToString();
            return data;
        }
    

        //GET : api/Bookings/UserId
        [ResponseType(typeof(Booking))]
        public IEnumerable<Booking> GetBooking(string UserId)
        {
            var data = db.Bookings.Where(b => b.UserId == UserId);
            if (data == null)
            {
                return null;
            }

            return data;
        }

       //returns a partiular object based on user input
       // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IEnumerable<Booking> GetBooking(Guid id)
        {

         var booking= db.Bookings.Where(b => b.BookingId == id);
            if (booking == null)
            {
                return null;
            }
            return booking;
           
        }


        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(Guid id, [FromBody]Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            var data = new Booking
            {


                BookingId = Guid.NewGuid(),
                CleanerId = booking.CleanerId,
                UserId = booking.UserId,
                EndDate = booking.EndDate,
                StartDate = booking.StartDate,
                ExtraDescription = booking.ExtraDescription,

                IsCompleted = booking.IsCompleted,
                IsHavePets = booking.IsHavePets,
                IsNeedCleaningMaterials = booking.IsNeedCleaningMaterials,
                IsNeedIroning = booking.IsNeedIroning,
                ServiceDuration = booking.ServiceDuration,
                ServiceTime = booking.ServiceTime,
                ModeOfEntry = booking.ModeOfEntry,
                PaymentMethod = booking.PaymentMethod,
                ServiceType = booking.ServiceType,
                TotalCost = booking.TotalCost,
                City = booking.City,
                HomeNumber = booking.HomeNumber,
                DirectionsOrLandmarks = booking.DirectionsOrLandmarks,
                Street = booking.Street,
                DateCreated = booking.DateCreated
            };
            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(data);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }



        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var data = new Booking
                {
                    BookingId = Guid.NewGuid(),
                    CleanerId = booking.CleanerId,
                    UserId = booking.UserId,
                    EndDate = booking.EndDate,
                    StartDate = booking.StartDate,
                    ExtraDescription = booking.ExtraDescription,

                    IsCompleted = booking.IsCompleted,
                    IsHavePets = booking.IsHavePets,
                    IsNeedCleaningMaterials = booking.IsNeedCleaningMaterials,
                    IsNeedIroning = booking.IsNeedIroning,
                    ServiceDuration = booking.ServiceDuration,
                    ServiceTime = booking.ServiceTime,
                    ModeOfEntry = booking.ModeOfEntry,
                    PaymentMethod = booking.PaymentMethod,
                    ServiceType = booking.ServiceType,
                    TotalCost = booking.TotalCost,
                    City = booking.City,
                    HomeNumber = booking.HomeNumber,
                    DirectionsOrLandmarks = booking.DirectionsOrLandmarks,
                    Street = booking.Street,
                    DateCreated = booking.DateCreated
                };
                try
                {
                    db.Bookings.Add(data);
                    db.SaveChanges();
                    return Ok(data);
                }
                catch (DbUpdateException)
                {
                    if (BookingExists(booking.BookingId))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(Guid id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(Guid id)
        {
            return db.Bookings.Count(e => e.BookingId == id) > 0;
        }
    }
}