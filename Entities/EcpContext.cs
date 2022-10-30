using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class EcpContext : DbContext
    {
        public EcpContext()
        {
        }

        public EcpContext(DbContextOptions<EcpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentVolunteer> AssignmentVolunteers { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.EventIdFk).HasColumnName("EventId_FK");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.HasOne(d => d.EventIdFkNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.EventIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event");
            });

            modelBuilder.Entity<AssignmentVolunteer>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Assignment)
                    .WithMany()
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignment");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerUser");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(512);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.OrganizerIdFk).HasColumnName("OrganizerID_FK");

                entity.HasOne(d => d.OrganizerIdFkNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.OrganizerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizerUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
