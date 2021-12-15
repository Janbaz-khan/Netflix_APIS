using HomeTag_Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Repository.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DB db;
        private Status status;

        public GenreRepository(DB dB)
        {
            this.db = dB;
            status = new Status();
        }


        public async Task<Status> AddGenreAsync(Genre Genre)
        {
            try
            {
                if (Genre != null)
                {
                    var duplicate = db.Genres.Where(a => a.GenreName == Genre.GenreName).Count();
                    if (duplicate>0)
                    {
                        status.IsSuccess = false;
                        status.Message = "Record with same name is already in the database";
                        return status;
                    }
                    await db.Genres.AddAsync(Genre);
                    await db.SaveChangesAsync();
                    status.IsSuccess = true;
                    status.Message = "Genre has been added successfully.";
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

        public async Task<Status> DeleteGenreAsync(long GenreId)
        {
            try
            {
                var SingleGenre = await db.Genres.FindAsync(GenreId);
                if (SingleGenre != null)
                {
                    db.Genres.Remove(SingleGenre);
                    await db.SaveChangesAsync();
                    status.IsSuccess = true;
                    status.Message = "Genre has been deleted successfully.";
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

        public List<Genre> GetGenres()
        {
            var GenresList = db.Genres.ToList();
            if (GenresList != null)
            {
                return GenresList;
            }
            else
            {
                return null;
            }
        }
    }
}
