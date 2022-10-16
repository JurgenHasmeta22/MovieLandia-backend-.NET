using System;
using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Favorite
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
