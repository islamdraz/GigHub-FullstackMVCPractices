using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace FullStackCourse1.Persistance.Repository
{
    public class GigRepository : IGigRepository
    {
        IApplicationDbContext _context;
        public GigRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Gig Get(int id)
        {
            return _context.Gigs
                  .Include(p => p.Genre)
                  .Include(p => p.Artist)
                  .SingleOrDefault(g => g.Id == id);
        }

        public Gig GetGigWithAttendees(int id)
        {
            return _context.Gigs
                .Include(p => p.Attendences.Select(a => a.Attendee))
                .SingleOrDefault(g => g.Id == id);

        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
           return _context.Attendences
                .Where(p => p.AttendeeId == userId)
                .Select(p => p.Gig)
                .Include(p => p.Artist)
                .Include(p => p.Genre).ToList();
        }

        public IEnumerable<Gig> GetArtistFutureGigs(string artistId)
        {
            return _context.Gigs
                  .Where(p => p.ArtistId == artistId && p.Datetime > DateTime.Now && !p.IsCanceled)
                  .Include(p => p.Artist)
                  .Include(p => p.Genre).ToList();
        }

        public IEnumerable<Gig> GetFutureGigs()
        {
         return   _context.Gigs.
                Include(p => p.Artist).
                Include(p => p.Genre).
                Where(p => p.Datetime > DateTime.Now).ToList();
        }
    }  
}