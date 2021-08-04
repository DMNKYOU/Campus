
using CampusCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusCRM.Contexts
{
    public sealed class CampusContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public CampusContext()
        {
            Database.EnsureCreated();
        }
        public CampusContext(DbContextOptions<CampusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CampusCRM_DB;Trusted_Connection=True;");
        }
    }
}