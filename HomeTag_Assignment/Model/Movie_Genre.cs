using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Model
{
    [Table("MovieGenre")]

    public class Movie_Genre
    {
        [Key]
        public long Id { get; set; }
        public long MovieId { get; set; }
        public long GenreId { get; set; }

        [ForeignKey("MovieId")]
        public Movie movie { get; set; }
        [ForeignKey("GenreId")]
        public Genre genre { get; set; }
    }
}
