using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xCubeApplication.Models;

namespace xCubeApplication.ClientDAL
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<UserDetails> Users { get; set; }

        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>(b =>
            {
                b.Property(e=>e.ID).HasColumnName("ID")
                    .HasColumnType("nvarchar(450)");

                b.Property(e=>e.Age).HasColumnName("Age")
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar(10)");

                b.Property(e=>e.ContactNumber).HasColumnName("ContactNumber")
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("nvarchar(10)");

                b.Property(e=>e.DateOfBirth).HasColumnName("DateOfBirth")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property(e=>e.Name).HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property(e=>e.ProfileImagePath).HasColumnName("ProfileImagePath")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("ID");

                b.ToTable("Users");
            });
            base.OnModelCreating(modelBuilder);
        }

        // Configuring connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SV37\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}
