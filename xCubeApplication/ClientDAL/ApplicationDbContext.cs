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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>(b =>
            {
                b.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int")  // Changed to int if you're using integer for ID
                    .ValueGeneratedOnAdd(); // Ensures the ID is generated on add

                b.Property(e => e.Age)
                    .HasColumnName("Age")
                    .IsRequired()
                    .HasColumnType("int"); // Changed to int for age, as it should be numeric

                b.Property(e => e.ContactNumber)
                    .HasColumnName("ContactNumber")
                    .IsRequired()
                    .HasMaxLength(15) // Adjusted max length to 15 to accommodate different formats
                    .HasColumnType("nvarchar(15)"); // Kept nvarchar for contact numbers

                b.Property(e => e.DateOfBirth)
                    .HasColumnName("DateOfBirth")
                    .IsRequired()
                    .HasColumnType("date"); // Use date type for DateOfBirth instead of nvarchar

                b.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property(e => e.ProfileImagePath)
                    .HasColumnName("ProfileImagePath")
                    .HasColumnType("nvarchar(max)"); // Keep as nvarchar(max) for file paths

                b.HasKey(e => e.ID); // Ensures ID is the primary key

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
