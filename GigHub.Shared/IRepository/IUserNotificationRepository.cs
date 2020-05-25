using System.Collections.Generic;
using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
    public interface IUserNotificationRepository
    {
        IEnumerable<UserNotification> GetUserNotification(string userId);
    }
}