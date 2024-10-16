using System;
using System.Collections.Generic;
using _21100602_EP.Entities;
using Microsoft.EntityFrameworkCore;

namespace _21100602_EP.Data;

public partial class Parcial2024221100602Context : DbContext
{
    public Parcial2024221100602Context()
    {
    }

    public Parcial2024221100602Context(DbContextOptions<Parcial2024221100602Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Competency> Competency { get; set; }

    public virtual DbSet<JobOffer> JobOffer { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competency>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
