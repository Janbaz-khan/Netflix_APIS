using HomeTag_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HomeTag_Assignment.Repository.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DB db;
        private Status status;

        public MovieRepository(DB dB)
        {
            this.db = dB;
            status = new Status();
        }
        public async Task<Status> AddMovieAsyc(Movie Movie)
        {
            try
            {
                if (Movie != null)
                {
                    var duplicate = db.Movies.Where(a => a.MovieName == Movie.MovieName).Count();
                    if (duplicate > 0)
                    {
                        status.IsSuccess = false;
                        status.Message = "Record with same name is already in the database";
                        return status;
                    }
                    
                    await db.Movies.AddAsync(Movie);
                     db.SaveChanges();

                    foreach (var item in Movie.AssociatedGenreList.ToList())
                        {
                            var newmany = new Movie_Genre();
                            newmany.GenreId = item.GenreId;
                            newmany.MovieId = Movie.MovieId;
                           await db.MoviesGenres.AddAsync(newmany);
                        }
                    
                    await db.SaveChangesAsync();
                    
                    status.IsSuccess = true;
                    status.Message = "Movie has been added successfully.";
                }
                else
                {
                    status.IsSuccess = false;
                    status.Message = "Validation field for this record.";
                }
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }
            return status;
        }

        public async Task<Status> DeleteMovieAsync(long MovieId)
        {
            try
            {
                var SingleMovie = await db.Movies.FindAsync(MovieId);
                if (SingleMovie != null)
                {
                    db.Movies.Remove(SingleMovie);
                    await db.SaveChangesAsync();
                    status.IsSuccess = true;
                    status.Message = "Movie has been deleted successfully.";
                }
                else
                {
                    status.IsSuccess = false;
                    status.Message = "Couldn't find any record with this Id.";
                }
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
                status.Message = ex.Message;
            }
            return status;
        }

        public List<Movie> GetMovies()
        {
            var MoviesList = db.Movies.Include("AssociatedGenreList").ToList();
            if (MoviesList != null)
            {
                //foreach (var item in MoviesList)
                //{
                //    var AssociateGenre = genres.Where(a => item.GenreIds.Any()).ToList();
                //    item.AssociatedGenreList.AddRange(AssociateGenre);
                //}
                return MoviesList;
            }
            else
            {
                return null;
            }
        }
    }
}
