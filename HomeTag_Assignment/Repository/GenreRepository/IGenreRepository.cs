using HomeTag_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Repository.GenreRepository
{
   public interface IGenreRepository
    {
        List<Genre> GetGenres();
        Task<Status> AddGenreAsync(Genre Genre);
        Task<Status> DeleteGenreAsync(long GenreId);
    }
}
