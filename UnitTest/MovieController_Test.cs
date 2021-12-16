using System;
using System.Collections.Generic;
using System.Text;
using HomeTag_Assignment.Controllers;
using HomeTag_Assignment.Model;
using HomeTag_Assignment.Repository.MovieRepository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace HomiTag_UnitTests
{
  public class MovieController_Test
    {
            private readonly MovieController _controller;
            private readonly IMovieRepository _service;

            public MovieController_Test()
            {
                //_service = new IMovieRepository();
                _controller = new MovieController(_service);
            }

            [Fact]
            public void Get_WhenCalled_ReturnsOkResult()
            {
                // Act
                var okResult = _controller.GetMovies();

                // Assert
                Assert.IsType<OkObjectResult>(okResult);
            }

            [Fact]
            public void Get_WhenCalled_ReturnsAllItems()
            {
                // Act
                var okResult = _controller.GetMovies();

                // Assert
                var items = Assert.IsType<List<Movie>>(okResult);
                Assert.Equal(2, items.Count);
            }
        }
    
}
