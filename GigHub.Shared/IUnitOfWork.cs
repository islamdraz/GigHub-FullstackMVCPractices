using GigHub.Shared.IRepository;

namespace GigHub.Shared
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendences { get; }
        IArtistFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IGigRepository Gigs { get; }

        IApplicationUserRepository ApplicationUsers { get; }

        INotificationRepository Notifications { get; }

        IUserNotificationRepository UserNotifications { get; }

        void Complete();
    }
}