using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class CommentUser
    {
        public int CommentUserId { get; set; }
        public int CommentId { get; set; }
        public string UserId { get; set; }
    }
}
