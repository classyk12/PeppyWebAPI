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
    public class FeedbacksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Feedbacks
        public IEnumerable<Feedback> GetFeedbacks()
        {
            return db.Feedbacks.OrderByDescending(f => f.Id);
        }


        //GET: api/Feedbacks? UserId
        //returns all feedbacks particular to the user
        //errors of json seraliaizing in postman when this method is called is solved,
        //refer to ApplicationDbContext in IdentityModel
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult GetFeedback(string UserId)
        {
            //Feedback feedback = db.Feedbacks.Find(feedback.UserId);
            var data = db.Feedbacks.Where(f => f.UserId == UserId);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        //gets the total number of feedback sent by a user
        public string GetFeedbacks(string user)
        {
            var data = db.Feedbacks.Where(f => f.UserId == user).Count().ToString();
            return data;
        }

       
        //gets the total number of feedbacks in the feedbacks table
        [Route("api/Feedbacks2")]
        public string GetFeedBack()
        {
            var data = db.Feedbacks.Count().ToString();
            return data;
        }

        //gets the mean feedback(sum(Rating)/count(users))
        [Route("api/Feedbacks4")]
        public string GetFeedBacks()
        {
            int data1 = db.Feedbacks.Select(f => f.Rating).Sum();
            int data2 = db.Feedbacks.Select(f => f.UserId).Count();
            int mean = (data1 / data2);
            var final = mean.ToString();
            return final;

        }

        //gets the total user in the feebacks table
        [Route("api/Feedbacks3")]
        public string GetFeedback()
        {
            var data = db.Feedbacks.Select(c => c.UserId).Distinct().Count().ToString();
            return data;
        }

        // POST: api/Feedbacks
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult PostFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = new Feedback
            {
                Id = feedback.Id,
                Title = feedback.Title,
                Body = feedback.Body,
                Rating = feedback.Rating,
                DateAdded = feedback.DateAdded,
                UserId = feedback.UserId,
                username = feedback.username
            };

            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Ok(data);
           
        }

        // DELETE: api/Feedbacks/5
        [ResponseType(typeof(Feedback))]
        public IHttpActionResult DeleteFeedback(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return NotFound();
            }

            db.Feedbacks.Remove(feedback);
            db.SaveChanges();

            return Ok(feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeedbackExists(int id)
        {
            return db.Feedbacks.Count(e => e.Id == id) > 0;
        }
    }
}