using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pract8_TRPO4.Models;

public partial class UdilovTrpo48zadContext : DbContext
{
    public UdilovTrpo48zadContext()
    {
    }

    public UdilovTrpo48zadContext(DbContextOptions<UdilovTrpo48zadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=sql.ects;Database=udilov_trpo4_8zad;User Id=student_00;Password=student_00;TrustServerCertificate=True;");
    }

    //"Server=sql.ects;Database=udilov_trpo4_8zad;User Id=student_00;Password=student_00;TrustServerCertificate=True;"

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.TaskIdSequence")
            .HasColumnName("ID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR dbo.UserIdSequence")
            .HasColumnName("ID");
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
