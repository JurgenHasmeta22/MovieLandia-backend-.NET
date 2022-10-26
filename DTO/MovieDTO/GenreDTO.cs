using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<MovieGenreDTO> MovieGenres { get; set; }
    }
}
