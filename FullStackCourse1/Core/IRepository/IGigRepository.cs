using System.Collections.Generic;

using FullStackCourse1.Core.Models;

namespace FullStackCourse1.Core.IRepository
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig Get(int id);
        IEnumerable<Gig> GetArtistFutureGigs(string artistId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);

        IEnumerable<Gig> GetFutureGigs();
        
        Gig GetGigWithAttendees(int id);
    }
}