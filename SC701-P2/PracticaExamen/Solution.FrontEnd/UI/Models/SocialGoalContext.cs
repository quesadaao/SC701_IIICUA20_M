using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace UI.Models
{
    public partial class SocialGoalContext : DbContext
    {
        public SocialGoalContext()
        {
        }

        public SocialGoalContext(DbContextOptions<SocialGoalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentUser> CommentUsers { get; set; }
        public virtual DbSet<Focus> Foci { get; set; }
        public virtual DbSet<FollowRequest> FollowRequests { get; set; }
        public virtual DbSet<FollowUser> FollowUsers { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<GoalStatus> GoalStatuses { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupComment> GroupComments { get; set; }
        public virtual DbSet<GroupCommentUser> GroupCommentUsers { get; set; }
        public virtual DbSet<GroupGoal> GroupGoals { get; set; }
        public virtual DbSet<GroupInvitation> GroupInvitations { get; set; }
        public virtual DbSet<GroupRequest> GroupRequests { get; set; }
        public virtual DbSet<GroupUpdate> GroupUpdates { get; set; }
        public virtual DbSet<GroupUpdateSupport> GroupUpdateSupports { get; set; }
        public virtual DbSet<GroupUpdateUser> GroupUpdateUsers { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Metric> Metrics { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<RegistrationToken> RegistrationTokens { get; set; }
        public virtual DbSet<SecurityToken> SecurityTokens { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<SupportInvitation> SupportInvitations { get; set; }
        public virtual DbSet<Update> Updates { get; set; }
        public virtual DbSet<UpdateSupport> UpdateSupports { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-FO3F74S\\SQLEXPRESS;Database=SocialGoal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.ProviderKey })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.CommentText).HasMaxLength(250);
            });

            modelBuilder.Entity<CommentUser>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<Focus>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FocusName).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Foci)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Foci_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<FollowRequest>(entity =>
            {
                entity.Property(e => e.FromUserId).IsRequired();

                entity.Property(e => e.ToUserId).IsRequired();
            });

            modelBuilder.Entity<FollowUser>(entity =>
            {
                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.ApplicationUserId)
                    .HasMaxLength(128)
                    .HasColumnName("ApplicationUser_Id");

                entity.Property(e => e.ApplicationUserId1)
                    .HasMaxLength(128)
                    .HasColumnName("ApplicationUser_Id1");

                entity.Property(e => e.FromUserId).HasMaxLength(128);

                entity.Property(e => e.ToUserId).HasMaxLength(128);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.FollowUserApplicationUsers)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ApplicationUser_Id");

                entity.HasOne(d => d.ApplicationUserId1Navigation)
                    .WithMany(p => p.FollowUserApplicationUserId1Navigations)
                    .HasForeignKey(d => d.ApplicationUserId1)
                    .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ApplicationUser_Id1");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.FollowUserFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_FromUserId");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.FollowUserToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ToUserId");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Desc).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GoalName)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Goals)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Goals_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<GoalStatus>(entity =>
            {
                entity.ToTable("GoalStatus");

                entity.Property(e => e.GoalStatusType).HasMaxLength(50);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<GroupComment>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                    .WithMany(p => p.GroupComments)
                    .HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupComments_dbo.GroupUpdates_GroupUpdateId");
            });

            modelBuilder.Entity<GroupCommentUser>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<GroupGoal>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GoalName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupInvitation>(entity =>
            {
                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupInvitations)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupInvitations_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<GroupRequest>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.Groups_GroupId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<GroupUpdate>(entity =>
            {
                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GroupUpdateSupport>(entity =>
            {
                entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                    .WithMany(p => p.GroupUpdateSupports)
                    .HasForeignKey(d => d.GroupUpdateId)
                    .HasConstraintName("FK_dbo.GroupUpdateSupports_dbo.GroupUpdates_GroupUpdateId");
            });

            modelBuilder.Entity<GroupUpdateUser>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<RegistrationToken>(entity =>
            {
                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<SecurityToken>(entity =>
            {
                entity.Property(e => e.ActualId).HasColumnName("ActualID");
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.Property(e => e.SupportedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SupportInvitation>(entity =>
            {
                entity.Property(e => e.SentDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Update>(entity =>
            {
                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UpdateSupport>(entity =>
            {
                entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DateEdited).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
