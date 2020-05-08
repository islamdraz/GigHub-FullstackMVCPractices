using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.EntityConfiguration
{
    public class ApplicationUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(p => p.Followees)
                .WithRequired(p => p.Artist)
                .WillCascadeOnDelete(false);

            HasMany(p => p.UserNotifications)
                .WithRequired(p => p.User)
                .WillCascadeOnDelete(false);

        }
    }
}