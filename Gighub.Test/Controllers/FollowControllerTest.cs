using FluentAssertions;
using FullStackCourse1.Controllers;
using FullStackCourse1.Core;
using Gighub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;
using GigHub.Model.Models;
using GigHub.Shared;
using GigHub.Shared.IRepository;

namespace Gighub.Test.Controllers
{
    [TestClass]
    public class FollowControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private FollowController _followController;
        private string _userId;
        private Mock<IApplicationUserRepository> _applicationUsersRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _applicationUsersRepo = new Mock<IApplicationUserRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.ApplicationUsers).Returns(_applicationUsersRepo.Object);
            _followController = new FollowController(_unitOfWork.Object);
            _userId = "1";
            _followController.MockCurrentUser(_userId, "test@test.com");

        }

        [TestMethod]
        public void ArtistFollow_ValidRequest_ViewResult()
        {
            _applicationUsersRepo.Setup(a => a.GetArtistsIFollowing(_userId)).Returns(new List<ApplicationUser>());
            var result = _followController.ArtistFollow();
            result.Should().BeOfType<ViewResult>();

        }
    }
}
