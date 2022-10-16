using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class MovieGenreDTO
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int GenreId { get; set; }

        public virtual GenreDTO1 Genre { get; set; } = null!;
       
    }
}
