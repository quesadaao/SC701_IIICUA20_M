using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class GroupGoal
    {
        public int GroupGoalId { get; set; }
        public string GoalName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? Target { get; set; }
        public int? MetricId { get; set; }
        public int? FocusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int GoalStatusId { get; set; }
        public int GroupUserId { get; set; }
        public int? AssignedGroupUserId { get; set; }
        public string AssignedTo { get; set; }
        public int GroupId { get; set; }
    }
}
