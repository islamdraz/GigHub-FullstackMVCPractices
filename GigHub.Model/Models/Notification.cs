using System;

namespace GigHub.Model.Models
{
    public class Notification
    {
      
        public int Id { get; private set; }

     
        public DateTime DateTime { get; private set; }

        public DateTime? OriginalDateTime { get;private set; }
        public string OriginalVenue { get;private set; }

        public Gig Gig { get; private set; }


      
        public int GigId { get;private set; }

        
        public NotificationType Type { get; private set; }

        private Notification(Gig gig,NotificationType type)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");
            Gig = gig;
            DateTime = DateTime.Now;
            Type = type;
        }

        protected Notification()
        {

        }

        public static Notification GigUpdated(Gig gig, DateTime originalDatetime,string originalVenue)
        {
            Notification Notification = new Notification
            {
                DateTime = DateTime.Now,
                Gig = gig,
                Type = NotificationType.Update,
                OriginalDateTime = originalDatetime,
                OriginalVenue = originalVenue

            };

            return Notification;
        }


        public static Notification GigCancel(Gig gig)
        {
            Notification notification = new Notification(gig, NotificationType.Cancel);

            return notification;
        }
    }
}