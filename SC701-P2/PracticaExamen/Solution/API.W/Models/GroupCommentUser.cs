using System;
using System.Collections.Generic;



namespace API.W.Models
{
    public partial class GroupCommentUser
    {
        public int GroupCommentUserId { get; set; }
        public int GroupCommentId { get; set; }
        public string UserId { get; set; }
    }
}
