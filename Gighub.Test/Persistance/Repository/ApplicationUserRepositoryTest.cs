using FluentAssertions;
using Gighub.Test.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using FullStackCourse1.Persistance;
using FullStackCourse1.Persistance.Repository;
using GigHub.Model.Models;


namespace Gighub.Test.Persistance.Repository
{
    [TestClass]
    public class ApplicationUserRepositoryTest
    {
        private ApplicationUserRepository _repository;
        private Mock<IApplicationDbContext> _mockApplicationDbContext;


        [TestInitialize]
        public void InitializeTest()
        {

            _mockApplicationDbContext = new Mock<IApplicationDbContext>();
            _repository = new ApplicationUserRepository(_mockApplicationDbContext.Object);

        }

        [TestMethod]
        public void GetArtistsIFollowing_WhenCall_ReturnArtistsList()
        {
            _mockApplicationDbContext.Setup(c => c.ArtistFollowers)
                .Returns(DbSetSourceMock.GetQueryableMockDbSet(new ArtistFollower { FollowerId = "1", Artist = new ApplicationUser() { Id = "1" } }));

            var result = _repository.GetArtistsIFollowing("1");
            result.Count().Should().Be(1);

        }


    }
}
