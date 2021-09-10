using System;
using CampusCRM.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CampusCRM.DAL.Contexts
{
    public sealed class CampusContext : IdentityDbContext
    {
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Group> Groups { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<Topic> Topics { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<StudentRequest> StudentRequests { get; set; } = default!;

        public CampusContext(): base()
        {
            //Database.EnsureDeleted();   
            //Database.EnsureCreated();   
        }
        public CampusContext(DbContextOptions<CampusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)/////////////////////////////////base variant!
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            // optionsBuilder.UseSqlServer(configuration.GetConnectionString("CampusConnectionStringDB"));
           // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CampusCRMDB;Trusted_Connection=True;");
        }
    }
}