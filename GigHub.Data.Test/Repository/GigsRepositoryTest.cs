using FluentAssertions;
using Gighub.Test.Helper;
using GigHub.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using GigHub.Data;
using GigHub.Data.Repository;

namespace Gighub.Test.Persistance.Repository
{
    [TestClass]
    public class GigsRepositoryTest
    {
        private GigRepository _repository;
        private Mock<IApplicationDbContext> _mockContext;


        [TestInitialize]
        public void TestInitialize()
        {
            _mockContext = new Mock<IApplicationDbContext>();
            _repository = new GigRepository(_mockContext.Object);
        }

        [TestMethod]
        public void GetUpcomingGigsByArtist_GigIsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() { Datetime = DateTime.Now.AddDays(-1), ArtistId = "1" };

            _mockContext.Setup(x => x.Gigs).Returns(DbSetSourceMock.GetQueryableMockDbSet(gig));

            var gigs = _repository.GetArtistFutureGigs("1");

            gigs.Should().BeEmpty();
        }
    }
}
