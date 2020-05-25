using FullStackCourse1.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Shared;

namespace FullStackCourse1.Controllers.Api
{
    [Authorize]
    public class GigsApiController : ApiController
    {
        
        IUnitOfWork _unitOfWork;
        public GigsApiController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            if (gig == null||gig.IsCanceled)
                return NotFound();
            if (User.Identity.GetUserId() != gig.ArtistId)
                return Unauthorized();

            gig.Cancel();
            _unitOfWork.Complete();
                       
            return Ok(id);

        }
    }
}
