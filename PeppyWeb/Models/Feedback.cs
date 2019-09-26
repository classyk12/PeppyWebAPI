using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeppyWeb.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string DateAdded { get; set; }
        public int Rating { get; set; }
        //represents one testimonial to one user
        public virtual ApplicationUser User { get; set; }
        public string username { get; set; }
        public string UserId { get; set; }
    }
}