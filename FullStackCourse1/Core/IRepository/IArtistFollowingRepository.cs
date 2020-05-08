using FullStackCourse1.Core.Models;
using System.Collections.Generic;

namespace FullStackCourse1.Core.IRepository
{
    public interface IArtistFollowingRepository
    {
        ArtistFollower GetFollower(string artistId, string userId);
        void Add(ArtistFollower artistFollower);

        void Remove(ArtistFollower artistFollower);

    }
}