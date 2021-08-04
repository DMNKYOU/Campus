using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using CampusCRM.Models;

namespace CampusCRM.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var student1 = new Student()
            {
                Id = 1,
                Name = "Petr",
                Surname = "Petrachko",
                Age = 21,
            };
            var student2 = new Student()
            {
                Id = 2,
                Name = "Dmitriy",
                Surname = "Muraska",
                Age = 22,
            };
            modelBuilder.Entity<Group>().HasData(student1, student2);

        }
    }
}
