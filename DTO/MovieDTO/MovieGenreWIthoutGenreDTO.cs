using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class MovieGenreWithoutGenreDTO
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public virtual MovieWithoutMovieGenreDTO Movie { get; set; } = null!;
    }
}
