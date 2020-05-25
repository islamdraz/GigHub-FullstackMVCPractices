using System.Collections.Generic;
using System.Linq;
using GigHub.Model.Models;
using GigHub.Shared.IRepository;

namespace GigHub.Persistance.Repository
{
    public class GenreRepository : IGenreRepository
    {
        IApplicationDbContext _context;
        public GenreRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}