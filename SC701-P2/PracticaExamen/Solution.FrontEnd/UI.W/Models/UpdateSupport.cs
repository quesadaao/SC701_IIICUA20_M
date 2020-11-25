using System;
using System.Collections.Generic;



namespace UI.W.Models
{
    public partial class UpdateSupport
    {
        public int UpdateSupportId { get; set; }
        public int UpdateId { get; set; }
        public string UserId { get; set; }
        public DateTime UpdateSupportedDate { get; set; }
    }
}
