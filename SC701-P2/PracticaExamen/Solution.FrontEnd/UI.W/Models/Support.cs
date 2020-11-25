using System;
using System.Collections.Generic;



namespace UI.W.Models
{
    public partial class Support
    {
        public int SupportId { get; set; }
        public int GoalId { get; set; }
        public string UserId { get; set; }
        public DateTime SupportedDate { get; set; }
    }
}
