using System;
using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Favorites = new HashSet<Favorite>();
        }

        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Password { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
