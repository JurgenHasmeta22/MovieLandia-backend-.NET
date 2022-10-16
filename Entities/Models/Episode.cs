using System;
using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Episode
    {
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
        public string VideoSrc { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public int SerieId { get; set; }

        public virtual Serie Serie { get; set; } = null!;
    }
}
