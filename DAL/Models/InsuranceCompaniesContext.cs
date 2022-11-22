using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class InsuranceCompaniesContext : DbContext
    {
        public InsuranceCompaniesContext()
        {
        }

        public InsuranceCompaniesContext(DbContextOptions<InsuranceCompaniesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accident> Accidents { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyHolder> PolicyHolders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=InsuranceCompanies;Username=postgres;Password=qaz16073011");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Accident>(entity =>
            {
                entity.ToTable("accident");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("location");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Accidents)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accident_car_id_fkey");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.CarNumber, "car_car_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("car_number");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("car_customer_id_fkey");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.Name, "company_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.ToTable("policy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IssuedDate)
                    .HasColumnType("date")
                    .HasColumnName("issued_date");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("policy_company_id_fkey");
            });

            modelBuilder.Entity<PolicyHolder>(entity =>
            {
                entity.ToTable("policy_holder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.PolicyId).HasColumnName("policy_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PolicyHolders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("policy_holder_customer_id_fkey");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.PolicyHolders)
                    .HasForeignKey(d => d.PolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("policy_holder_policy_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
