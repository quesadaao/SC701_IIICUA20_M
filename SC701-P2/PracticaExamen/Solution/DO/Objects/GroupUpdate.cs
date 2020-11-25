using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public partial class GroupUpdate
    {
        public GroupUpdate()
        {
            GroupComments = new HashSet<GroupComment>();
            GroupUpdateSupports = new HashSet<GroupUpdateSupport>();
        }

        public int GroupUpdateId { get; set; }
        public string Updatemsg { get; set; }
        public double? Status { get; set; }
        public int GroupGoalId { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<GroupComment> GroupComments { get; set; }
        public virtual ICollection<GroupUpdateSupport> GroupUpdateSupports { get; set; }
    }
}
