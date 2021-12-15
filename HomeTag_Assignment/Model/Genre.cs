using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTag_Assignment.Model
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public long GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }

}
