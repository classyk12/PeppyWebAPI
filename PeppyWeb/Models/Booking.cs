using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PeppyWeb.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }

        //gets the ID of the cleaner hired for the service
        public int CleanerId { get; set; }
        public virtual Cleaner Cleaner { get; set; }

        [Required] //gets the Id of the user placing the booking
        //Foreign key property of the User Table
        public string UserId { get; set; }
        //references the User table from this property
        public virtual ApplicationUser User { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string ServiceType { get; set; }

        [Required]
        public string StartDate { get; set; }

        public string EndDate { get; set; }


        [Required]
        //how long you want the cleaner to stay
        public double ServiceDuration { get; set; }

        [Required]
        //what time should the cleaner show up
        public string ServiceTime { get; set; }

        //extra description of anything the user wants to let the cleaner know
        public string ExtraDescription { get; set; }

        public bool IsNeedIroning { get; set; }

        public bool IsNeedCleaningMaterials { get; set; }

        public bool IsHavePets { get; set; }

        [Required]
        public string ModeOfEntry { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string Street { get; set; }

        public string HomeNumber { get; set; }

        [Required]
        public string City { get; set; }

        public string DirectionsOrLandmarks { get; set; }


        //returns the full address of the User
        public string FullAddress
        {
            get
            {
                return HomeNumber + ", " + Street + "," + City + " " + "near" + " " + DirectionsOrLandmarks + "," + "Lagos";
            }
        }

       
        public bool IsCompleted { get; set; }

        [Required]
        public string TotalCost { get; set; }
    }
}