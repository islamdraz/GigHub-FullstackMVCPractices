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
public    class NotificationTest
    {

        [TestMethod]
        public void GigUpdate_WhenCall_NewNotificationWithUpdateType()
        {
            var gig=new Gig();
            
            var notification = Notification.GigUpdated(gig, DateTime.Now, "test");

            notification.Type.Should().Be(NotificationType.Update);
            notification.Gig.Should().Be(gig);
        }

        [TestMethod]
        public void GigCancel_WhenCall_NewNotificationWithCancelType()
        {
            var gig = new Gig();

            var notification = Notification.GigCancel(gig);

            notification.Type.Should().Be(NotificationType.Cancel);
            notification.Gig.Should().Be(gig);
        }
    }
}
