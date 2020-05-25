using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace FullStackCourse1.Persistance.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        IApplicationDbContext _context;
        public NotificationRepository(IApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Notification> GetUserNotification(string userId)
        {
            return _context.UserNotifications
                  .Where(un => un.UserId == userId && !un.IsRead)
                  .Select(p => p.Notification)
                  .Include(p => p.Gig.Artist)
                  .ToList();
        }


    }
}