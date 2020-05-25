﻿using FullStackCourse1.Core;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Shared;

namespace FullStackCourse1.Controllers
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