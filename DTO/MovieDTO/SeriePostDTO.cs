using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class SeriePostDTO
    {
        public string Title { get; set; } = null!;
        public string PhotoSrc { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public float RatingImdb { get; set; }
    }
}
