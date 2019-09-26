using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace PeppyWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //illustrates many bookings to one user
        public ICollection<Booking> Bookings { get; set; }
        //illustrates many feedacks to one user
        public ICollection<Feedback> feedbacks { get; set; }

        //public string PhoneNumber { get; set; }
        //represents the username
        public string Alias { get; set; }
        //represents when the user signed up
        public DateTime DateJoined { get; set; }
        //represents users profile picture
        [NotMapped]
        public byte[] ImageArray { get; set; }
        //represents the uri of the users picture
        public string ImagePath { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this configuration setting helps solve errors from getting Feedbacks using a userId
            this.Configuration.LazyLoadingEnabled = false;
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //specifies the relationship between one user to many feedbacks
            //UserId Column is made the foreign key property
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(f => f.feedbacks)
                .WithRequired(a => a.User)
                .HasForeignKey(a => a.UserId);

            //specifies the relationship between one user to many bookings
            //UserId column is made the foreign key property
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(b => b.Bookings)
                .WithRequired(u => u.User)
                .HasForeignKey(u => u.UserId);


            modelBuilder.Entity<Cleaner>()
             .HasMany(b => b.bookings)
             .WithRequired(c => c.Cleaner)
             .HasForeignKey(c => c.CleanerId);



            base.OnModelCreating(modelBuilder);
        }


        public System.Data.Entity.DbSet<PeppyWeb.Models.Offer> Offers { get; set; }

        public System.Data.Entity.DbSet<PeppyWeb.Models.Feedback> Feedbacks { get; set; }

        public System.Data.Entity.DbSet<PeppyWeb.Models.Cleaner> Cleaners { get; set; }

        public System.Data.Entity.DbSet<PeppyWeb.Models.Booking> Bookings { get; set; }

       
    }
}