using System.Web.Http;
using GigHub.Model;
using GigHub.Model.Models;
using GigHub.Shared;
using Microsoft.AspNet.Identity;

namespace GigHub.Web.Controllers.Api
{
    [Authorize]
    public class GigsApiController : ApiController
    {
        private GenericRepository<Gig> _repository; 

        IUnitOfWork _unitOfWork;
        public GigsApiController(IUnitOfWork unitOfWork , GenericRepository<Gig> repository)
        {
            _repository = repository;

             _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);
            //var gig = _repository.FindByKey(id);
            if (gig == null||gig.IsCanceled)
                return NotFound();
            if (User.Identity.GetUserId() != gig.ArtistId)
                return Unauthorized();

            gig.Cancel();

          //  _repository.Update(gig);
            _unitOfWork.Complete();
                       
            return Ok(id);

        }
    }
}
