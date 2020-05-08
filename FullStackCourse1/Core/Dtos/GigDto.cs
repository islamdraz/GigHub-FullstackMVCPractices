using System;

namespace FullStackCourse1.Core.Dtos
{
    public class GigDto
    {

        public int Id { get;  set; }
        public bool IsCanceled { get;  set; }
        public ApplicationUserDto Artist { get; set; }
        public string ArtistId { get; set; }
        public DateTime Datetime { get; set; }
        public string Venue { get; set; }

        
    }
}