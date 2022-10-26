using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
