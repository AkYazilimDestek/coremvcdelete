using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataSilmeCoreMvc.Models;

public partial class KisilerContext : DbContext
{
    public KisilerContext()
    {
    }

    public KisilerContext(DbContextOptions<KisilerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kisiler> Kisilers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Kisiler;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kisiler>(entity =>
        {
            entity.HasKey(e => e.KisiId);

            entity.ToTable("Kisiler");

            entity.Property(e => e.KisiName).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
