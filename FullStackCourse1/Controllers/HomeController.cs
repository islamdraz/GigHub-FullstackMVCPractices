using System;
using System.Linq;
using System.Web.Mvc;
using GigHub.Shared;
using GigHub.Web.Core.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Web.Controllers
{
    public class HomeController : Controller
    {
       
        IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index(string query = null)
        {
            var Gigs = _unitOfWork.Gigs.GetFutureGigs();
            if (!String.IsNullOrWhiteSpace(query))
            {
                Gigs = Gigs.Where(p =>
                  p.Artist.Name.Contains(query) ||
                  p.Venue.Contains(query) ||
                  p.Genre.Name.Contains(query));
            }


            var gigsAteending = _unitOfWork.Attendences.GetUserAttendances(User.Identity.GetUserId())
                                  .ToLookup(p => p.GigId);

         

            var viewModel = new GigsViewModel()
            {
                UpCommingGigs = Gigs,
                IsAuthorized = User.Identity.IsAuthenticated,
                PageHeader="Home",
                SearchTerm=query,
                Attendences=gigsAteending
                

            };
            return View("Gigs",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}