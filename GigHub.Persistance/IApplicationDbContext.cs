using System.Data.Entity;
using GigHub.Model.Models;

namespace GigHub.Persistance
{
    public interface IApplicationDbContext
    {
        DbSet<Gig> Gigs { get; set; }
        DbSet<Genre> Genres { get; set; }

        DbSet<ArtistFollower> ArtistFollowers { get; set; }
        DbSet<Attendence> Attendences { get; set; }
        DbSet<Notification> Notifications { get; set; }

        DbSet<UserNotification> UserNotifications { get; set; }
    }
}