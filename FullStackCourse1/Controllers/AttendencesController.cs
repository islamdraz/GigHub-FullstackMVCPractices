using System.Linq;
using System.Web.Http;
using GigHub.Model.Models;
using GigHub.Shared;
using GigHub.Web.Core.Dtos;
using Microsoft.AspNet.Identity;

namespace GigHub.Web.Controllers
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
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(attendDto.GigId);
            if (gig == null)
                return BadRequest($"No gig exists with id {attendDto.GigId}");
            if (gig.Attendences.Any(a=>a.AttendeeId==User.Identity.GetUserId()))
            {
                return BadRequest("you already attending this gig");
            }
            Attendence attendance = new Attendence
            {
                AttendeeId = User.Identity.GetUserId(),
                GigId = attendDto.GigId
            };
            _unitOfWork.Attendences.Add(attendance);
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
