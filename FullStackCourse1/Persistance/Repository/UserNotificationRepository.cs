using System.Collections.Generic;
using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace FullStackCourse1.Persistance.Repository
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        IApplicationDbContext _context;
        public UserNotificationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotification(string userId)
        {
            return _context.UserNotifications.Where(p => p.UserId == userId).ToList();
        }
    }
}