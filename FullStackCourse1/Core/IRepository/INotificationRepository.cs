using System.Collections.Generic;
using FullStackCourse1.Core.Models;

namespace FullStackCourse1.Core.IRepository
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUserNotification(string userId);
    }
}