using HomeTag_Assignment.Controllers;
using HomeTag_Assignment.Model;
using HomeTag_Assignment.Repository.GenreRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HomiTag_UnitTests
{
   public class GenreController_Test
    {
        private readonly GenreController _controller;
        private readonly IGenreRepository _service;

        public GenreController_Test()
        {
            //_service = new IGenreRepository();
            _controller = new GenreController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetGenres();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetGenres();

            // Assert
            var items = Assert.IsType<List<Genre>>(okResult);
            Assert.Equal(2, items.Count);
        }
    }
}
