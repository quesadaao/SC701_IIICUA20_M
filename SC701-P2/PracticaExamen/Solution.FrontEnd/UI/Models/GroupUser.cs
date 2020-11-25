using System;
using System.Collections.Generic;



namespace UI.Models
{
    public partial class GroupUser
    {
        public int GroupUserId { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public bool Admin { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
