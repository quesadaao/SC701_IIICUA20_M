using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class GroupUpdateSupport
    {
        public int GroupUpdateSupportId { get; set; }
        public int GroupUpdateId { get; set; }
        public int GroupUserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }

        public virtual GroupUpdate GroupUpdate { get; set; }
    }
}
