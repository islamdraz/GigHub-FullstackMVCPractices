using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using FullStackCourse1.Core.Models;
using FullStackCourse1.Persistance.EntityConfiguration;

namespace FullStackCourse1.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<ArtistFollower> ArtistFollowers { get; set; }
        public DbSet<Attendence> Attendences { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<UserNotification> UserNotifications { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            modelBuilder.Configurations.Add(new GigConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());

            modelBuilder.Entity<Notification>()
                .HasRequired(p => p.Gig)
                .WithMany(g => g.Notifications);

            base.OnModelCreating(modelBuilder);
        }
    }
}