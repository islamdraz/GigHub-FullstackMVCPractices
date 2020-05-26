using System.Data.Entity.ModelConfiguration;
using GigHub.Model.Models;

namespace GigHub.Data.EntityConfiguration
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