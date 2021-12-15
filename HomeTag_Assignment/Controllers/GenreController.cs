using HomeTag_Assignment.Model;
using HomeTag_Assignment.Repository.GenreRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository genreRepository;

        public GenreController(IGenreRepository igenreRepository)
        {
            this.genreRepository = igenreRepository;
        }

        [HttpGet]
        public List<Genre> GetGenres()
        {
            return genreRepository.GetGenres();
           

        }
        [HttpPost]
        public async Task<Status> AddGenre(Genre Genre)
        {
            return await genreRepository.AddGenreAsync(Genre);
            
        }
        [HttpDelete("{id}")]
        public async Task<Status> DeleteGenre(long id)
        {
            return await genreRepository.DeleteGenreAsync(id);
           
        }
    }
}
