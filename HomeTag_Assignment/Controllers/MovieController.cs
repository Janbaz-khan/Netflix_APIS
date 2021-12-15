using HomeTag_Assignment.Model;
using HomeTag_Assignment.Repository.GenreRepository;
using HomeTag_Assignment.Repository.MovieRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return movieRepository.GetMovies();
           

        }
        [HttpPost]
        public async Task<Status> AddMovie(Movie movie)
        {
            return await movieRepository.AddMovieAsyc(movie);
           
        }
        [HttpDelete("{id}")]
        public async Task<Status> DeleteMovie(long id)
        {
            return await movieRepository.DeleteMovieAsync(id);
            
        }
    }
}
