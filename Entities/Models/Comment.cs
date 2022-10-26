using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
