using Microsoft.EntityFrameworkCore;
using System;
using CampusCRM.DAL.Entities;
using Group = CampusCRM.DAL.Entities.Group;

namespace CampusCRM.DAL.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teacher1 = new Teacher()
            {
                Id = 1,
                Name = "Alisa",
                Surname = "Kolisnekach",
                Age = 48,
                Info = "Middle+ developer, play tennis and read fiction",
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                Name = "Vlad",
                Surname = "Losher",
                Age = 34,
                Info = "I like cooking or baking and creating new projects in educational sphere",
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2);

            var group1 = new Group()
            {
                Id = 1,
                Name = "IOS",
                StartDate = DateTime.Parse("09.09.2021"),
                TeacherId = teacher1.Id,
            };
            var group2 = new Group()
            {
                Id = 2,
                Name = "Front-end",
                StartDate = DateTime.Parse("31.10.2021"),
                TeacherId = teacher2.Id,
            };
            modelBuilder.Entity<Group>().HasData(group1, group2);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 5,
                    Name = "Dmitriy",
                    Surname = "Murashka",
                    Age = 21,
                    GroupId = group1.Id
                },
                new Student()
                {
                    Id = 6,
                    Name = "Tanya",
                    Surname = "Petrachko",
                    Age = 22,
                    GroupId = group1.Id
                }
            );

        }
    }
}