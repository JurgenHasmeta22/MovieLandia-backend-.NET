using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MovieDTO
{
    public class EpisodeInSerieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string PhotoSrc { get; set; } = null!;
        public string VideoSrc { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SerieId { get; set; }
    }
}
