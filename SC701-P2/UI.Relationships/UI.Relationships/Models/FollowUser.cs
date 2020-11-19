using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class FollowUser
    {
        public int FollowUserId { get; set; }
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public bool Accepted { get; set; }
        public DateTime AddedDate { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserId1 { get; set; }

        public virtual AspNetUser ApplicationUser { get; set; }
        public virtual AspNetUser ApplicationUserId1Navigation { get; set; }
        public virtual AspNetUser FromUser { get; set; }
        public virtual AspNetUser ToUser { get; set; }
    }
}
