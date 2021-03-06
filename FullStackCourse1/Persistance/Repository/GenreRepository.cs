﻿using FullStackCourse1.Core.IRepository;
using FullStackCourse1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FullStackCourse1.Persistance.Repository
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