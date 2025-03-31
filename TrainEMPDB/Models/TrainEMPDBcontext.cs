using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainEMPDB.Models;

public partial class TrainEMPDBcontext : DbContext
{
    public TrainEMPDBcontext()
    {
    }

    public TrainEMPDBcontext(DbContextOptions<TrainEMPDBcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbsDetail> AbsDetails { get; set; }

    public virtual DbSet<Absent> Absents { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<UsingTime> UsingTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmpData;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Chinese_Taiwan_Stroke_CS_AS");

        modelBuilder.Entity<AbsDetail>(entity =>
        {
            entity.HasKey(e => e.EmpNo);

            entity.ToTable("AbsDetail");

            entity.Property(e => e.EmpNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AbsDate).HasColumnType("datetime");
            entity.Property(e => e.AbsType)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Absent>(entity =>
        {
            entity.HasKey(e => e.AbsType);

            entity.ToTable("Absent");

            entity.Property(e => e.AbsType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.AbsName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__Dept__0148CAAE600E6369");

            entity.ToTable("Dept");

            entity.Property(e => e.DeptNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Birth)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DeptNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsingTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UsingTime");

            entity.Property(e => e.LogInTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
