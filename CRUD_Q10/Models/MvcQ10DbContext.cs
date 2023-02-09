using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Q10.Models;

public partial class MvcQ10DbContext : DbContext
{
    public MvcQ10DbContext()
    {
    }

    public MvcQ10DbContext(DbContextOptions<MvcQ10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTest> TblTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //        => optionsBuilder.UseSqlServer("server=localhost; database=MVC_Q10_DB; integrated security=true; TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTest>(entity =>
        {
            entity.HasKey(e => e.PruebaIdentificacion).HasName("PK_tbl_Test");

            entity.ToTable("TblTest");

            entity.Property(e => e.PruebaIdentificacion)
                .ValueGeneratedNever()
                .HasColumnName("pruebaIdentificacion");
            entity.Property(e => e.PruebaApellidos)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pruebaApellidos");
            entity.Property(e => e.PruebaGenero)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pruebaGenero");
            entity.Property(e => e.PruebaMail)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pruebaMail");
            entity.Property(e => e.PruebaNombre)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("pruebaNombre");
            entity.Property(e => e.PruebaTelefono).HasColumnName("pruebaTelefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
