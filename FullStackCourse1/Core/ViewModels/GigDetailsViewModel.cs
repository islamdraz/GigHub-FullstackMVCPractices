using System;
using GigHub.Model.Models;

namespace GigHub.Web.Core.ViewModels
{
    public class GigDetailsViewModel
    {

        public bool IsCanceled { get;  set; }
        public ApplicationUser Artist { get; set; }

     
        public string ArtistId { get; set; }

        public DateTime Datetime { get; set; }

        
        public string Venue { get; set; }


        public Genre Genre { get; set; }

      

        public bool IsUserAuthorized { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }

    }
}