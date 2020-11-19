using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class GroupComment
    {
        public int GroupCommentId { get; set; }
        public string CommentText { get; set; }
        public int GroupUpdateId { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual GroupUpdate GroupUpdate { get; set; }
    }
}
