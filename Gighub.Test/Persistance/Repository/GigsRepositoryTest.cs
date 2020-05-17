using System;
using FluentAssertions;
using FullStackCourse1.Core.Models;
using FullStackCourse1.Persistance;
using FullStackCourse1.Persistance.Repository;
using Gighub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Gighub.Test.Persistance.Repository
{
    [TestClass]
    public class GigsRepositoryTest
    {
        private GigRepository _repository;
        private Mock<DbSet<Gig>> _mockGigs;
       
        [TestInitialize]
        public void TestInitialize()
        {
            _mockGigs = new Mock<DbSet<Gig>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Gigs).Returns(_mockGigs.Object);
            _repository = new GigRepository(mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() { Datetime = DateTime.Now.AddDays(-1), ArtistId = "1" };

            _mockGigs.SetSource(new[] { gig });

            var gigs = _repository.GetArtistFutureGigs("1");

            gigs.Should().BeEmpty();
        }
    }
}
