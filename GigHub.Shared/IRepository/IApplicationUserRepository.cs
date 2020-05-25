using System.Collections.Generic;
using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
  public  interface IApplicationUserRepository
    {

        IEnumerable<ApplicationUser> GetArtistsIFollowing(string userId);
    }
}
