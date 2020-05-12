using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using FullStackCourse1.Persistance;
using FullStackCourse1.Persistance.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gighub.Test.Persistance.Repository
{
    [TestClass]
    public  class ApplicationUserRepositoryTest
    {
        private ApplicationUserRepository _applicationUserRepository;
        private Mock<IApplicationDbContext> _mockApplicationDbContext;
        private Mock<DbSet<ArtistFollower>> _mockArtistsFollowDbSet;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockArtistsFollowDbSet = new Mock<DbSet<ArtistFollower>>();
            _mockApplicationDbContext =new Mock<IApplicationDbContext>();
            _mockApplicationDbContext.SetupGet(c => c.ArtistFollowers).Returns(_mockArtistsFollowDbSet.Object);
            _applicationUserRepository = new ApplicationUserRepository(_mockApplicationDbContext.Object);
        }
        [TestMethod]
        public void GetArtistsIFollowing_WhenCall_ReturnArtistsList()
        {
            


        }
    }
}
