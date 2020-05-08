using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.EntityConfiguration
{
    public class NotificationConfiguration:EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.DateTime)
                .IsRequired();

            Property(p => p.Type)
                .IsRequired();

            HasRequired(p => p.Gig)
                .WithMany(p => p.Notifications);
        }
    }
}