// <auto-generated />
using System;
using CampusCRM.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampusCRM.DAL.Migrations
{
    [DbContext(typeof(CampusContext))]
    [Migration("20210808213254_Changefirlino")]
    partial class Changefirlino
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampusCRM.DAL.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Name = "IOS",
                            StartDate = new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = 10
                        },
                        new
                        {
                            Id = 11,
                            Name = "Front-end",
                            StartDate = new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TeacherId = 11
                        });
                });

            modelBuilder.Entity("CampusCRM.DAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Age = 21,
                            GroupId = 10,
                            Name = "Dmitriy",
                            Surname = "Murashka"
                        },
                        new
                        {
                            Id = 11,
                            Age = 22,
                            GroupId = 10,
                            Name = "Tanya",
                            Surname = "Petrachko"
                        });
                });

            modelBuilder.Entity("CampusCRM.DAL.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Age = 48,
                            Info = "Middle+ developer, play tennis and read fiction",
                            Name = "Alisa",
                            Surname = "Kolisnekach"
                        },
                        new
                        {
                            Id = 11,
                            Age = 34,
                            Info = "I like cooking or baking and creating new projects in educational sphere",
                            Name = "Vlad",
                            Surname = "Losher"
                        });
                });

            modelBuilder.Entity("CampusCRM.DAL.Entities.Group", b =>
                {
                    b.HasOne("CampusCRM.DAL.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CampusCRM.DAL.Entities.Student", b =>
                {
                    b.HasOne("CampusCRM.DAL.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("CampusCRM.DAL.Entities.Group", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
