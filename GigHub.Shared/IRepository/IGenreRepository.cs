using System.Collections.Generic;
using GigHub.Model.Models;

namespace GigHub.Shared.IRepository
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
    }
}