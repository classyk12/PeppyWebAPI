using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PeppyWeb.Models
{
    public class Cleaner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public bool IsAvailable { get; set; }

        public string ImagePath { get; set; }
        public ICollection<Booking> bookings { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }
    }
}