using FullStackCourse1.Core;
using FullStackCourse1.Core.Models;
using FullStackCourse1.Persistance;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

            if (gig == null)
                return NotFound();
            if (User.Identity.GetUserId() != gig.ArtistId)
                return Unauthorized();
            if (gig.IsCanceled)
                return NotFound();
            gig.Cancel();
            _unitOfWork.Complete();
                       
            return Ok(id);

        }
    }
}
