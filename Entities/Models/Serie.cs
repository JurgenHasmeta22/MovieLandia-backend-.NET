﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Serie
    {
        public Serie()
        {
            Episodes = new HashSet<Episode>();
        }
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string PhotoSrc { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public float RatingImdb { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
