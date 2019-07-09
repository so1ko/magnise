﻿// <auto-generated />
using System;
using EfCoreSample.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreSample.Persistance.Migrations
{
    [DbContext(typeof(EfCoreSampleDbContext))]
    [Migration("20190708200237_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EfCoreSample.Doman.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("EmployeeId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("City", "Country", "Street")
                        .HasAnnotation("MySql:FullTextIndex", true);

                    b.ToTable("address","efcoresample");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Ternopil",
                            Country = "Ukraine",
                            EmployeeId = 1L,
                            Street = "Lvivs`ka"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Ternopil",
                            Country = "Ukraine",
                            EmployeeId = 2L,
                            Street = "Tarnavs`kogo"
                        });
                });

            modelBuilder.Entity("EfCoreSample.Doman.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EfCoreSample.Doman.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("current_timestamp(6) ON UPDATE current_timestamp(6)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<long?>("ReportsToId");

                    b.HasKey("Id");

                    b.HasIndex("ReportsToId");

                    b.ToTable("employee","efcoresample");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "Petro",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Petrenko"
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "Olga",
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Petrenko"
                        });
                });

            modelBuilder.Entity("EfCoreSample.Doman.EmployeeDepartment", b =>
                {
                    b.Property<long>("EmployeeId");

                    b.Property<long>("DepartmentId");

                    b.HasKey("EmployeeId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("EmployeeDepartment");
                });

            modelBuilder.Entity("EfCoreSample.Doman.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discription")
                        .HasMaxLength(128);

                    b.Property<long>("EmployeeId");

                    b.Property<DateTime>("EndTime")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("current_timestamp(6) ON UPDATE current_timestamp(6)");

                    b.Property<DateTime>("LastUpdateTime")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("current_timestamp(6) ON UPDATE current_timestamp(6)");

                    b.Property<DateTime>("StartTime")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("current_timestamp(6) ON UPDATE current_timestamp(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Title", "Discription")
                        .HasAnnotation("MySql:FullTextIndex", true);

                    b.ToTable("Project","efcoresample");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discription = "Discription",
                            EmployeeId = 0L,
                            EndTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending",
                            Title = "Title"
                        },
                        new
                        {
                            Id = 2,
                            Discription = "Discription2",
                            EmployeeId = 0L,
                            EndTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Pending",
                            Title = "Title2"
                        });
                });

            modelBuilder.Entity("EfCoreSample.Doman.Address", b =>
                {
                    b.HasOne("EfCoreSample.Doman.Employee", "Employee")
                        .WithMany("Addresses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfCoreSample.Doman.Employee", b =>
                {
                    b.HasOne("EfCoreSample.Doman.Employee", "ReportsTo")
                        .WithMany("ReportsToEmployees")
                        .HasForeignKey("ReportsToId");
                });

            modelBuilder.Entity("EfCoreSample.Doman.EmployeeDepartment", b =>
                {
                    b.HasOne("EfCoreSample.Doman.Department", "Department")
                        .WithMany("EmployeeDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EfCoreSample.Doman.Employee", "Employee")
                        .WithMany("EmployeeDepartments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfCoreSample.Doman.Entities.Project", b =>
                {
                    b.HasOne("EfCoreSample.Doman.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
