using System.Data.Entity.ModelConfiguration;
using GigHub.Model.Models;

namespace GigHub.Data.EntityConfiguration
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