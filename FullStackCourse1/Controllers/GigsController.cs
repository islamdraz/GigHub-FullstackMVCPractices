using FullStackCourse1.Core.Models;
using FullStackCourse1.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FullStackCourse1.Persistance;
using FullStackCourse1.Core;

namespace FullStackCourse1.Controllers
{
    public class GigsController : Controller
    {
       
        IUnitOfWork _unitofWork;
        public GigsController(IUnitOfWork unitOfWork)
        {

            _unitofWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult Search(GigsViewModel viewmodel)
        {
           
         return   RedirectToAction("Index", "Home",new { query = viewmodel.SearchTerm });
        }


        public ViewResult GigView(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _unitofWork.Gigs.Get(id);

            var viewmodel = new GigDetailsViewModel
            {
                Artist = gig.Artist,
                Datetime = gig.Datetime,
                Genre = gig.Genre,
                Venue = gig.Venue,
                IsAttending =_unitofWork.Attendences.GetAttendance(id,userId)!=null,
                IsFollowing=_unitofWork.Followings.GetFollower(gig.ArtistId,userId)!=null,
                IsUserAuthorized=User.Identity.IsAuthenticated
            };

            return View("GigView",viewmodel);
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var ViewModel = new GigViewModel
            {
                Genres = _unitofWork.Genres.GetAll(),
                Heading = "Create Gig"
            };
            return View("GigForm",ViewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(GigViewModel viewModel)
        {
            //var userId = User.Identity.GetUserId();

            //solve this by create forignkey
            //var artist = _context.Users.Single(p => p.Id ==userId );
            //var genre = _context.Genres.Single(p => p.Id == viewModel.Genre);
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitofWork.Genres.GetAll();
                return View("GigForm", viewModel);

            }

            Gig gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                Datetime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _unitofWork.Gigs.Add(gig);
            _unitofWork.Complete();
            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public ActionResult Edit(int gigId)
        {

            var gig = _unitofWork.Gigs.Get(gigId);
            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewModel = new GigViewModel
            {
                Id = gigId,
                Date = gig.Datetime.ToString("dd MMM yyyy"),
                Time = gig.Datetime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Genres = _unitofWork.Genres.GetAll(),
                Heading = "Update Gig"
            };

            return View("GigForm", viewModel);

        }

        [Authorize]
        [HttpPost]
        public ActionResult Update(GigViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitofWork.Genres.GetAll();
                return View("GigForm", viewModel);
            }
            
            var gig = _unitofWork.Gigs.GetGigWithAttendees(viewModel.Id);
            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();




            gig.Update(viewModel.GetDateTime(), viewModel.Genre, viewModel.Venue);

            _unitofWork.Complete();

            return RedirectToAction("Mine");
        }

        [Authorize]
        public ActionResult UpcommingGigs()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _unitofWork.Gigs.GetGigsUserAttending(userId);

            var attendences = _unitofWork.Attendences.GetUserAttendances(userId)
                .ToLookup(p => p.GigId);

            var viewModel = new GigsViewModel()
            {
                UpCommingGigs = gigs,
                IsAuthorized = User.Identity.IsAuthenticated,
                PageHeader="Up Comming Gigs",
                 Attendences=attendences
                
            };

            return View("Gigs",viewModel);
        }


        [Authorize]
        public ActionResult Mine()
        {
            
            var gigs = _unitofWork.Gigs.GetArtistFutureGigs(User.Identity.GetUserId());

         
            return View("MyGigs", gigs);
        }

    }
}