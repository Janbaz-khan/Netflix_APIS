using HomeTag_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Repository.MovieRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetMovies();
        Task<Status> AddMovieAsyc(Movie Movie);
        Task<Status> DeleteMovieAsync(long MovieId);
    }
}
