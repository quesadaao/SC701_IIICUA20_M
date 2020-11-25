using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class SolutionDBContext : DbContext
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options) : base(options)
        {

        }

        public SolutionDBContext()
        {
        }

        public virtual DbSet<GroupComment> GroupComments { get; set; }
        public virtual DbSet<GroupUpdate> GroupUpdates { get; set; }
        public virtual DbSet<GroupUpdateSupport> GroupUpdateSupports { get; set; }

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
            modelBuilder.Entity<GroupComment>(entity =>
            {
                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.HasOne(d => d.GroupUpdate)
                            .WithMany(p => p.GroupComments)
                            .HasForeignKey(d => d.GroupUpdateId)
                            .HasConstraintName("FK_dbo.GroupComments_dbo.GroupUpdates_GroupUpdateId");
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
        }

           
    }
}
