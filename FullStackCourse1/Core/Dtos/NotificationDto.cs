using FullStackCourse1.Core.Models;
using System;

namespace FullStackCourse1.Core.Dtos
{
    public class NotificationDto
    {
       
     
        public DateTime DateTime { get;  set; }

        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }

        public GigDto Gig { get;  set; }

        public NotificationType Type { get; private set; }



    }
}