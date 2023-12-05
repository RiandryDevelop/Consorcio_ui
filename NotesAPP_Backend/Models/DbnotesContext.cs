using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotesAPP_Backend.Models;

public partial class DbnotesContext : DbContext
{
    public DbnotesContext()
    {
    }

    public DbnotesContext(DbContextOptions<DbnotesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NotesScheme> NotesSchemes { get; set; }

    public virtual DbSet<TagsName> TagsNames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DBNotes; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotesScheme>(entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__NotesSch__4B2ACFF60E1A7740");

            entity.ToTable("NotesScheme");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsArchive).HasColumnName("isArchive");
            entity.Property(e => e.Owner)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.TagName).WithMany(p => p.NotesSchemes)
                .HasForeignKey(d => d.TagNameId)
                .HasConstraintName("FK__NotesSche__TagNa__403A8C7D");
        });

        modelBuilder.Entity<TagsName>(entity =>
        {
            entity.HasKey(e => e.TagNameId).HasName("PK__TagsName__AF300DA395C128A2");

            entity.Property(e => e.TagNameId).ValueGeneratedNever();
            entity.Property(e => e.TagName1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TagName_1");
            entity.Property(e => e.TagName2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TagName_2");
            entity.Property(e => e.TagName3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TagName_3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
