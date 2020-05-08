using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FullStackCourse1.Core.Models
{
    public class Gig
    {
        public int Id { get; private set; }

        public bool IsCanceled { get; private set; }
        public ApplicationUser Artist { get; set; }


        public string ArtistId { get; set; }

        public DateTime Datetime { get; set; }

        public string Venue { get; set; }

      
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }

        public ICollection<Notification> Notifications { get;private set; }
        public ICollection<Attendence>Attendences { get; private set; }

        public Gig()
        {
            Notifications = new List<Notification>();
            Attendences = new List<Attendence>();
        }
        public void Cancel()
        {
            IsCanceled = true;

            var notification = Notification.GigCancel(this);
            
            Notifications.Add(notification);          
            foreach (var user in Attendences.Select(p=>p.Attendee))
            {
                user.Notify(notification);
            }
        }

        public void Update(DateTime datetime, byte genreId,string venue)
        {
            if (datetime == null)
                throw new ArgumentNullException("datetime");
            


            if (venue == null)
                throw new ArgumentNullException("Venue");

            var notification =  Notification.GigUpdated(this,datetime,venue);

            Notifications.Add(notification);
            foreach (var user in Attendences.Select(p => p.Attendee))
            {
                user.Notify(notification);
            }

            Datetime = datetime;
            GenreId = genreId;
            Venue = venue;

            
        }
    }

   
}