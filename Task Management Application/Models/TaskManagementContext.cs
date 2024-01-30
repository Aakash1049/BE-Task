using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_Management_Application.Models;

public partial class TaskManagementContext : DbContext
{
    public TaskManagementContext()
    {
    }

    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskItemEntity> TaskItemEntities { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=IN-IT13679;Database=TaskManagement;Integrated Security=True;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItemEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskItem__3214EC072880F066");

            entity.ToTable("TaskItemEntity");

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaskStat__3214EC07D5C5E2E6");

            entity.ToTable("TaskStatus");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
