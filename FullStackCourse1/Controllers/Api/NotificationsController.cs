using FullStackCourse1.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

using AutoMapper;
using FullStackCourse1.Core.Dtos;
using FullStackCourse1.Persistance;
using FullStackCourse1.Core;
using WebGrease.Css.Extensions;

namespace FullStackCourse1.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
      
        private IUnitOfWork _unitOfWork;
        public NotificationsController(IUnitOfWork unitOfwork)
        {

            _unitOfWork = unitOfwork;
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var notification = _unitOfWork.Notifications.GetUserNotification(User.Identity.GetUserId());
            


            //return notification
            //    .Select(p => new NotificationDto
            //    {
            //        DateTime=p.DateTime,
            //         Gig=new GigDto
            //         {
            //              Artist=new ApplicationUserDto
            //              {
            //                  Id=p.Gig.Artist.Id,
            //                  Name=p.Gig.Artist.Name
            //              },
            //              Datetime=p.Gig.Datetime,
            //              Venue=p.Gig.Venue,
            //              IsCanceled=p.Gig.IsCanceled

            //         },
            //         OriginalDateTime=p.OriginalDateTime,
            //         OriginalVenue=p.OriginalVenue

            //    });

            return notification.Select(n=>Mapper.Map<Notification, NotificationDto>(n));
        }

        [HttpPost]
        public IHttpActionResult PostUpdateNotification()
        {
            var notifications = _unitOfWork.UserNotifications.GetUserNotification(User.Identity.GetUserId());

            notifications.ForEach(p => p.Read());

            _unitOfWork.Complete();

            return Ok();

        }
    }
}
