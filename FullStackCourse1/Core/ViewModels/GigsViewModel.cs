using System.Collections.Generic;
using System.Linq;
using GigHub.Model.Models;

namespace GigHub.Web.Core.ViewModels
{
    public class GigsViewModel
    {
        

        public bool IsAuthorized { get; internal set; }
        public IEnumerable<Gig> UpCommingGigs { get; set; }

        public string PageHeader { get; set; }

        public string SearchTerm { get; set; }
        public ILookup<int, Attendence> Attendences { get;  set; }
    }
}