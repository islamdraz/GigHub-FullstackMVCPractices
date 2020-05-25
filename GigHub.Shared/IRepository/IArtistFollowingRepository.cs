using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
    public interface IArtistFollowingRepository
    {
        ArtistFollower GetFollower(string artistId, string userId);
        void Add(ArtistFollower artistFollower);

        void Remove(ArtistFollower artistFollower);

    }
}