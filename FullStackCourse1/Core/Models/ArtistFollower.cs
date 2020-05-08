using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Core.Models
{
    public class ArtistFollower
    {
        public ApplicationUser Artist { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ArtistId { get; set; }


        public ApplicationUser Follower { get; set; }

        [Key]
        [Column(Order =2)]
        public string FollowerId { get; set; }

    }
}