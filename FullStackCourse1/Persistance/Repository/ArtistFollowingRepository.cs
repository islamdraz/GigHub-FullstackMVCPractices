using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.Repository
{
    public class ArtistFollowingRepository : IArtistFollowingRepository
    {
        ApplicationDbContext _context;

        public ArtistFollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ArtistFollower artistFollower)
        {
            _context.ArtistFollowers.Add(artistFollower);
        }

        public ArtistFollower GetFollower(string artistId,string userId)
        {
         return   _context.ArtistFollowers.SingleOrDefault(p => p.ArtistId == artistId && p.FollowerId == userId);
        }

        public void Remove(ArtistFollower artistFollower)
        {
            _context.ArtistFollowers.Remove(artistFollower);
        }
    }
}