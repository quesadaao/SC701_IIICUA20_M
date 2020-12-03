using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class GroupUpdateSupport
    {
        public int GroupUpdateSupportId { get; set; }
        public int GroupUpdateId { get; set; }
        public int GroupUserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }

        public virtual GroupUpdate GroupUpdate { get; set; }
    }
}
