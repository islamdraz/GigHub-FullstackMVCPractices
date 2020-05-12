using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private IApplicationDbContext _context;

        public ApplicationUserRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetArtistsIFollowing(string userId)
        {
            return _context.ArtistFollowers
                 .Where(p => p.FollowerId == userId)
                 .Select(p => p.Artist);
        }
    }
}