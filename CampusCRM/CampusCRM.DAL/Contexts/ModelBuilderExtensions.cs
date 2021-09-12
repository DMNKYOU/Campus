using Microsoft.EntityFrameworkCore;
using System;
using CampusCRM.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Group = CampusCRM.DAL.Entities.Group;

namespace CampusCRM.DAL.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teacher1 = new Teacher()
            {
                Id = 10,
                Name = "Alisa",
                Surname = "Kolisnekach",
                Age = 48,
                Info = "Middle+ developer, play tennis and read fiction",
            };
            var teacher2 = new Teacher()
            {
                Id = 11,
                Name = "Vlad",
                Surname = "Losher",
                Age = 34,
                Info = "I like cooking or baking and creating new projects in educational sphere",
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2);

            var t1 = new Topic()
            {
                Id = 1,
                Title = "TopicTitle1",
                Description = "CourseDescription1",
            };
            var t2 = new Topic()
            {
                Id = 2,
                Title = "TopicTitle2",
                Description = "TopicDescription2",
            };
            modelBuilder.Entity<Topic>().HasData(t1, t2);

            var c1 = new Course()
            {
                Id = 1,
                Title = "CourseTitle1",
                Description = "CourseDescription1",
                Program = "CourseProgram1",
                TopicId = 1
            };

            var c2 = new Course()
            {
                Id = 2,
                Title = "CourseTitle2",
                Description = "CourseDescription2",
                Program = "CourseProgram2",
                TopicId = 2
            };
            modelBuilder.Entity<Course>().HasData(c1, c2);

            var group1 = new Group()
            {
                Id = 10,
                Name = "IOS",
                StartDate = DateTime.Parse("09.09.2021"),
                TeacherId = teacher1.Id,
                CourseId = 1
            };
            var group2 = new Group()
            {
                Id = 11,
                Name = "Front-end",
                StartDate = DateTime.Parse("31.10.2021"),
                TeacherId = teacher2.Id,
                CourseId = 1
            };
            modelBuilder.Entity<Group>().HasData(group1, group2);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 10,
                    Name = "Dmitriy",
                    Surname = "Murashka",
                    Age = 21,
                    GroupId = group1.Id
                },
                new Student()
                {
                    Id = 11,
                    Name = "Tanya",
                    Surname = "Petrachko",
                    Age = 22,
                    GroupId = group1.Id
                },
                new Student()
                {
                    Id = 12,
                    Name = "Oksana",
                    Surname = "Kiurd",
                    Age = 22,
                    GroupId = null
                },
                new Student()
                {
                    Id = 13,
                    Name = "Larisa",
                    Surname = "Jiop",
                    Age = 24,
                    GroupId = null
                }
            ) ;

            modelBuilder.Entity<StudentRequest>().HasData(
                new StudentRequest()
                {
                    Id = 1,
                    StartDate = DateTime.Today.AddDays(+1),
                    Comment = "I want to learn!",
                    CourseId = 1,
                    StudentId = 12,
                    Status = Enums.RequestStatus.Open
                },
                new StudentRequest()
                {
                    Id = 2,
                    StartDate = DateTime.Today.AddDays(+1),
                    Comment = "I want to gain new knowledge!",
                    CourseId = 1,
                    StudentId = 13,
                    Status = Enums.RequestStatus.Open
                }
            );

            /*modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "admin" },
                new IdentityRole { Name = "manager" }
            );*/
        }
    }
}