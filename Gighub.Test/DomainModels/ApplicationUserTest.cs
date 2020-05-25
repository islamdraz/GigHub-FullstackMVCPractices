using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GigHub.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gighub.Test.DomainModels
{
    [TestClass]
public    class ApplicationUserTest
    {
        [TestMethod]
        public void Notify_WhenCall_NotificationAddedToUser()
        {
            var user = new ApplicationUser();

            var notification = Notification.GigCancel(new Gig());

            user.Notify(notification);

            user.UserNotifications.Count.Should().Be(1);
            user.UserNotifications.First().Notification.Should().Be(notification);
            user.UserNotifications.First().Notification.Type.Should().Be(NotificationType.Cancel);
        }

        [TestMethod]
        public void MarkNotificationsAsRead_WhenCall_ChangeSTatusOfNotificationsToRead()
        {
            var user=new ApplicationUser();


            var notification = Notification.GigCancel(new Gig());

            user.Notify(notification);
            
            user.MarkNotificationsAsRead();

            user.UserNotifications.First().IsRead.Should().Be(true);
        }
    }
}
