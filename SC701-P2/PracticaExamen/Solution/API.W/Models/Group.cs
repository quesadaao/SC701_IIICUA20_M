using System;
using System.Collections.Generic;



namespace API.W.Models
{
    public partial class Group
    {
        public Group()
        {
            Foci = new HashSet<Focus>();
            GroupInvitations = new HashSet<GroupInvitation>();
            GroupRequests = new HashSet<GroupRequest>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Focus> Foci { get; set; }
        public virtual ICollection<GroupInvitation> GroupInvitations { get; set; }
        public virtual ICollection<GroupRequest> GroupRequests { get; set; }
    }
}
