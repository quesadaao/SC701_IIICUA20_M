using System;
using System.Collections.Generic;



namespace UI.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UpdateId { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
