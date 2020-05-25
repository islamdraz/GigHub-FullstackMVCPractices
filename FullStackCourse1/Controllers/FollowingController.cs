using FullStackCourse1.Core;
using FullStackCourse1.Core.Dtos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHub.Model.Models;
using GigHub.Shared;

namespace FullStackCourse1.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
     
        IUnitOfWork _unitOfWork;

        public FollowingController(IUnitOfWork unitOfWork)
        {
          
            _unitOfWork = unitOfWork;

        }

      
        [HttpPost]
        public IHttpActionResult FollowArtist(FollowDto followDto)
        {
            if (_unitOfWork.Followings.GetFollower(followDto.ArtistId , User.Identity.GetUserId())!=null)
            {
                return BadRequest("You are following this artist already");
            }

            var followArtist = new ArtistFollower() {
                ArtistId=followDto.ArtistId,
                FollowerId=User.Identity.GetUserId()
            };

            _unitOfWork.Followings.Add(followArtist);
            _unitOfWork.Complete();


            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFollower(string id)
        {
            var follow = _unitOfWork.Followings.GetFollower(id, User.Identity.GetUserId());
            if (follow == null)
                return NotFound();

            _unitOfWork.Followings.Remove(follow);
            _unitOfWork.Complete();

            return Ok();


        }
    }
}
