using System;
using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class Comment
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
