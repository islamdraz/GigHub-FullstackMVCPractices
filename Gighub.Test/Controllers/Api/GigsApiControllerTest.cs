using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FullStackCourse1.Controllers.Api;
using FullStackCourse1.Core;
using Gighub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using Microsoft.AspNet.Identity;

namespace Gighub.Test.Controllers.Api
{
    [TestClass]
   public class GigsApiControllerTest
    {
        private GigsApiController _gigsController;
        private readonly Mock<IGigRepository> _gigRepoMock;
        private  string _userId;

        public GigsApiControllerTest()
        {
             _gigRepoMock=new Mock<IGigRepository>();
            var _unitOfWork =new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.Gigs).Returns(_gigRepoMock.Object);
             _gigsController=new GigsApiController(_unitOfWork.Object);

              _userId = "1";
             _gigsController.MockCurrentUser(_userId,"Test@test.com");
        }

        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ReturnNotFound()
        {
            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<NotFoundResult>();

        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ReturnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();
            gig.ArtistId = _gigsController.User.Identity.GetUserId();
            _gigRepoMock.Setup(g => g.GetGigWithAttendees(1)).Returns(gig);

           
            var result = _gigsController.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();

        }

        [TestMethod]
        public void Cancel_UserCancelHisGig_OkResult()
        {
            var gig = new Gig();
            gig.ArtistId = _gigsController.User.Identity.GetUserId();
            _gigRepoMock.Setup(g => g.GetGigWithAttendees(1)).Returns(gig);

            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<OkNegotiatedContentResult<int>>();

        }

        [TestMethod]
        public void Cancel_UserCancelAnotherUserGig_ReturnNotAuthorized()
        {
            var gig = new Gig();

            gig.ArtistId = _userId + "-";
            _gigRepoMock.Setup(g => g.GetGigWithAttendees(1)).Returns(gig);

            var result = _gigsController.Cancel(1);

            result.Should().BeOfType<UnauthorizedResult>();
        }

      
       
    }
}
