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

        // Configuring connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=YOUR_SERVER_NAME;Database=YourDatabaseName;Trusted_Connection=True;");
        }
    }
}
