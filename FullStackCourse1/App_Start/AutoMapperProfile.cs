using AutoMapper;
using GigHub.Model.Models;
using GigHub.Web.Core.Dtos;

namespace GigHub.Web
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