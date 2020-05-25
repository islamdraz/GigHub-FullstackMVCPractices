using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FullStackCourse1.Core.ViewModels;
using Microsoft.AspNet.Identity;
using FullStackCourse1.Core;
using GigHub.Shared;

namespace FullStackCourse1.Controllers
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