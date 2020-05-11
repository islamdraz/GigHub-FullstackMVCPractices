using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using FluentAssertions;
using FullStackCourse1.Controllers;
using FullStackCourse1.Core;
using FullStackCourse1.Core.Dtos;
using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using Gighub.Test.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gighub.Test.Controllers
{
    [TestClass]
public    class AttendanceControllerTest
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private AttendencesController _attendanceController;
        private string _userId;
        private Mock<IAttendanceRepository> _attendanceRepo;
        private Mock<IGigRepository> _gigRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _attendanceRepo=new Mock<IAttendanceRepository>();
            _gigRepository=new Mock<IGigRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _unitOfWork.Setup(u => u.Attendences).Returns(_attendanceRepo.Object);
            _unitOfWork.Setup(u => u.Gigs).Returns(_gigRepository.Object);

            _attendanceController = new AttendencesController(_unitOfWork.Object);
            _userId = "1";
            _attendanceController.MockCurrentUser(_userId,"Test@test.com");
        }

        [TestMethod]
        public void AddGigAttendance_GigNotExistsWithThisId_BadRequest()
        {
            var attendanceDto = new AttendDto {GigId = 1};

            var result=  _attendanceController.AddGigAttendance(attendanceDto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void AddGigAttendance_UserAlreadyAttendGig_BadRequestMessage()
        {
            var attendanceDto = new AttendDto { GigId = 1 };

            _gigRepository.Setup(g => g.GetGigWithAttendees(1))
                .Returns(new Gig {Attendences = {new Attendence {AttendeeId = _userId}}});
            var result = _attendanceController.AddGigAttendance(attendanceDto);

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void AddGigAttendance_ValidRequest_ShouldReturnOkWithAttendDto()
        {
            var attendanceDto = new AttendDto { GigId = 1 };

            _gigRepository.Setup(g => g.GetGigWithAttendees(1))
                .Returns(new Gig ());

            var result = _attendanceController.AddGigAttendance(attendanceDto);

            result.Should().BeOfType<OkResult>();
        }

    }
}
