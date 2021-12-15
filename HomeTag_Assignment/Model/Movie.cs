using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Model
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public long MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string ReleaseDate { get; set; }
        public string Duration { get; set; }
        public  string Rating { get; set; }
        public IList<Movie_Genre> AssociatedGenreList { get; set; }

    }
}
