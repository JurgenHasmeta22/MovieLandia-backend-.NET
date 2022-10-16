using System;
using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Serie
    {
        public Serie()
        {
            Episodes = new HashSet<Episode>();
        }

        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string PhotoSrc { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public int ReleaseYear { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public float RatingImdb { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
