﻿using GigHub.Persistance.Repository;
using GigHub.Shared;
using GigHub.Shared.IRepository;

namespace GigHub.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

      public IGigRepository Gigs { get; private set; }
      public  IAttendanceRepository Attendences { get; private set; }
        public  IArtistFollowingRepository Followings { get; private set; }
        public  IGenreRepository Genres { get; private set; }

        public IApplicationUserRepository ApplicationUsers { get; private set; }

        public INotificationRepository Notifications { get;private set; }

        public IUserNotificationRepository UserNotifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(_context);
            Attendences = new AttendanceRepository(_context);
            Followings = new ArtistFollowingRepository(_context);
            Genres = new GenreRepository(_context);
            ApplicationUsers = new ApplicationUserRepository(context);
            Notifications = new NotificationRepository(context);
            UserNotifications = new UserNotificationRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}