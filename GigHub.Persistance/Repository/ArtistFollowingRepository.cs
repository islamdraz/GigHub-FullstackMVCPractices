using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace GigHub.Persistance.Repository
{
    public class ArtistFollowingRepository : IArtistFollowingRepository
    {
        IApplicationDbContext _context;

        public ArtistFollowingRepository(IApplicationDbContext context)
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