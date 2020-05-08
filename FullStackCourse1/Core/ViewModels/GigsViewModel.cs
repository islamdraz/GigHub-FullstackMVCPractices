using System.Linq;
using FullStackCourse1.Core.Models;
using System.Collections.Generic;

namespace FullStackCourse1.Core.ViewModels
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