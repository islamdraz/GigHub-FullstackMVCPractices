using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackCourse1.Core.IRepository
{
  public  interface IApplicationUserRepository
    {

        IEnumerable<ApplicationUser> GetArtistsIFollowing(string userId);
    }
}
