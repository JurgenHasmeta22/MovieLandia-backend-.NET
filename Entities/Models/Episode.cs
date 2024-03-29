﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Episode
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string PhotoSrc { get; set; } = null!;
        public string VideoSrc { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; } = null!;
    }
}
