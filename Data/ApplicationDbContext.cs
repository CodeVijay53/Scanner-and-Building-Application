using Microsoft.EntityFrameworkCore;
using HKLS_App.Models;
using System.Reflection.Emit;

namespace HKLS_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=mauiauthapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Project Alpha" },
                new Project { Id = 2, Name = "Project Beta" },
                new Project { Id = 3, Name = "Project Gamma" }
            );
        }
    }
}
