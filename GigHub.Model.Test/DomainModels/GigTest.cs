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
    public class GigTest
    {
        [TestMethod]
        public void Cancel_CallCancel_IsCancelBeTrue()
        {
            var gig=new Gig();
            gig.Cancel();

            gig.IsCanceled.Should().Be(true);
        }

        [TestMethod]
        public void Method_HasAttendee_EachAttendeeGetNotification()
        {
            var gig = new Gig();

            var user = new ApplicationUser();
            
            gig.Attendences.Add(new Attendence{ Attendee=new ApplicationUser(){Id="1"}});

            gig.Cancel();

            gig.Attendences.First()
                .Attendee
                .UserNotifications
                .Count
                .Should().Be(1);

        }


        [TestMethod]
        public void Update_VenueIsNull_ThrowArgumentNullException()
        {
            var gig=new Gig();

            Assert.ThrowsException<ArgumentNullException>(()=>gig.Update(DateTime.Now, 1, null), "venue");
        }

        [TestMethod]
        public void Update_ValidRequest_ValuesShouldBeApplied()
        {
            var gig = new Gig();
            var date = DateTime.Now;
            gig.Update(date,1, "venue");

            gig.Datetime.Should().Be(date);
            gig.GenreId.Should().Be(1);
            gig.Venue.Should().Be("venue");
        }


        [TestMethod]
        public void Update_HasAttendees_EachOneGetNotification()
        {
            var gig = new Gig();
            var date = DateTime.Now;
            gig.Attendences.Add(new Attendence { Attendee = new ApplicationUser() { Id = "1" } });
            gig.Update(date, 1, "venue");

            gig.Attendences.First()
                .Attendee
                .UserNotifications
                .Count
                .Should().Be(1);
        }
    }
}
