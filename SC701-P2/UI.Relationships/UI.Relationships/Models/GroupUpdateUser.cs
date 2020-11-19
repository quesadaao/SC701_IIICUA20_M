using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class GroupUpdateUser
    {
        public int GroupUpdateUserId { get; set; }
        public int GroupUpdateId { get; set; }
        public string UserId { get; set; }
    }
}
