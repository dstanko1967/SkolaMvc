using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkolaMvc.Models
{
    public partial class SkolaContext : DbContext
    {
        public SkolaContext()
        {
        }

        public SkolaContext(DbContextOptions<SkolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Studenti> Studenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-013A96I\\SQLEXPRESS;Database=Skola;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Studenti>(entity =>
            {
                entity.HasKey(e => e.IdStudent);

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.DatumRođenja)
                    .HasColumnName("Datum rođenja")
                    .HasColumnType("date");

                entity.Property(e => e.Ime).HasMaxLength(15);

                entity.Property(e => e.MestoRođenja)
                    .HasColumnName("Mesto_rođenja")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime).HasMaxLength(25);
            });
        }
    }
}
