using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class MoviePostDTO
    {
        public string Title { get; set; } = null!;
        public string VideoSrc { get; set; } = null!;
        public string PhotoSrc { get; set; } = null!;
        public string TrailerSrc { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public float RatingImdb { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; } = null!;
        public int Views { get; set; }  
    }
}
