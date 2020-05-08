using FullStackCourse1.Core;
using FullStackCourse1.Core.Dtos;

using FullStackCourse1.Core.Models;
using FullStackCourse1.Persistance;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FullStackCourse1.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public AttendencesController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        [HttpPost]
        public IHttpActionResult AddGigAttendance(AttendDto attendDto)
        {
            if (_unitOfWork.Attendences.GetAttendance(attendDto.GigId, User.Identity.GetUserId())!=null)
            {
                return BadRequest("you already attending this gig");
            }
            Attendence attendece = new Attendence
            {
                AttendeeId = User.Identity.GetUserId(),
                GigId = attendDto.GigId
            };
            _unitOfWork.Attendences.Add(attendece);
            _unitOfWork.Complete();

            return Ok();
        }


        [HttpDelete]
        
        public IHttpActionResult DeleteAttendance (int id)
        {
            var attend = _unitOfWork.Attendences
                .GetAttendance( id, User.Identity.GetUserId());

            if (attend == null)
                return NotFound();

            _unitOfWork.Attendences.Remove(attend);
            _unitOfWork.Complete();

            return Ok();


        }
    }
}
