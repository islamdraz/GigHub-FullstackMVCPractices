using AutoMapper;
using FullStackCourse1.Core.Dtos;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.App_Start
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();
          

        }
    }
}