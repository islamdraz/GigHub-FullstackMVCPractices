using System.Collections.Generic;
using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUserNotification(string userId);
    }
}