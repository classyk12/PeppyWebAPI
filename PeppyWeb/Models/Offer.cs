using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PeppyWeb.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        //gets and sets the date when the offer expires
        public DateTime ExpiryDate { get; set; }
        [NotMapped]
        public byte[] ImageArray { get; set; }

        public bool IsAvailable { get; set; }
    }
}