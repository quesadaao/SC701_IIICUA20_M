using System;
using System.Collections.Generic;

#nullable disable

namespace UI.Relationships.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            FollowUserApplicationUserId1Navigations = new HashSet<FollowUser>();
            FollowUserApplicationUsers = new HashSet<FollowUser>();
            FollowUserFromUsers = new HashSet<FollowUser>();
            FollowUserToUsers = new HashSet<FollowUser>();
            Goals = new HashSet<Goal>();
            GroupRequests = new HashSet<GroupRequest>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public bool? Activated { get; set; }
        public int? RoleId { get; set; }
        public string Discriminator { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<FollowUser> FollowUserApplicationUserId1Navigations { get; set; }
        public virtual ICollection<FollowUser> FollowUserApplicationUsers { get; set; }
        public virtual ICollection<FollowUser> FollowUserFromUsers { get; set; }
        public virtual ICollection<FollowUser> FollowUserToUsers { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<GroupRequest> GroupRequests { get; set; }
    }
}
