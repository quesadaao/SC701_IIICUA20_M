using System;
using System.Collections.Generic;



namespace UI.Models
{
    public partial class Focus
    {
        public int FocusId { get; set; }
        public string FocusName { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Group Group { get; set; }
    }
}
