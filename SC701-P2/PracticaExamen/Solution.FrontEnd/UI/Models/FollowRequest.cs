using System;
using System.Collections.Generic;



namespace UI.Models
{
    public partial class FollowRequest
    {
        public int FollowRequestId { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public bool Accepted { get; set; }
    }
}
