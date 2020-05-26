using System.Web.Mvc;
using GigHub.Shared;
using Microsoft.AspNet.Identity;

namespace GigHub.Web.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {


        IUnitOfWork _unitOfWork;
        public FollowController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        // GET: Follow
        public ActionResult ArtistFollow()
        {
            var viewModel = _unitOfWork.ApplicationUsers
                                        .GetArtistsIFollowing((string)User.Identity.GetUserId());


            return View(viewModel);
        }
    }
}