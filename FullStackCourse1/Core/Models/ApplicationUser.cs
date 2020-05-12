using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace FullStackCourse1.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public ICollection<UserNotification> UserNotifications { get; private set; }
        public ICollection<ArtistFollower> Followees { get; set; }
       
        public ApplicationUser()
        {
            
            UserNotifications = new List<UserNotification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public void Notify(Notification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            UserNotifications.Add(new UserNotification(this, notification));

        }

        public void MarkNotificationsAsRead()
        {
            foreach (var un in UserNotifications)
            {
                un.Read();
            }

        }
    }

}