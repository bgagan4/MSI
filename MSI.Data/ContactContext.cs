using Microsoft.EntityFrameworkCore;
using MSI.Domain;

#nullable disable

namespace MSI.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<SubjectAddress> SubjectAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("Name");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Suffix)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SubjectAddress>(entity =>
            {
                entity.ToTable("SubjectAddress");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.SubjectAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectAddress_Address");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAddresses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectAddress_Name");
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
