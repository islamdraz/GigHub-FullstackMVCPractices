using System.Data.Entity.ModelConfiguration;
using GigHub.Model.Models;

namespace FullStackCourse1.Persistance.EntityConfiguration
{
    public class GigConfiguration : EntityTypeConfiguration<Gig>
    {
        public GigConfiguration()
        {
            Property(p => p.ArtistId)
                .IsRequired();

            Property(p => p.GenreId)
                .IsRequired();

            Property(p => p.Venue)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(p => p.Attendences)
                .WithRequired(p => p.Gig)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Notifications)
                .WithRequired(p => p.Gig);
                
        }
    }
}