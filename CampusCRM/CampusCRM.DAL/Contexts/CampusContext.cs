using CampusCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusCRM.DAL.Contexts
{
    public sealed class CampusContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public CampusContext()
        {
            //Database.EnsureDeleted();   
            Database.EnsureCreated();   
        }
        public CampusContext(DbContextOptions<CampusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CampusCRMDB;Trusted_Connection=True;");
        }
    }
}