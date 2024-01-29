using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestTechnique.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=corellia;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("projet_pk");

            entity.ToTable("projet");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.Date)
                .HasMaxLength(10)
                .HasColumnName("_date");
            entity.Property(e => e.Horaires)
                .HasColumnType("character varying")
                .HasColumnName("horaires");
            entity.Property(e => e.Meteo)
                .HasColumnType("character varying")
                .HasColumnName("meteo");
            entity.Property(e => e.Temp1).HasColumnName("temp1");
            entity.Property(e => e.Temp2).HasColumnName("temp2");
            entity.Property(e => e.Travail)
                .HasMaxLength(2)
                .HasColumnName("travail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
