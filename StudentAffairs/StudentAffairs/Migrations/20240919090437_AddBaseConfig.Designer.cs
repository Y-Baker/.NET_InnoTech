﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAffairs;

#nullable disable

namespace StudentAffairs.Migrations
{
    [DbContext(typeof(StudentsAffairsDbContext))]
    [Migration("20240919090437_AddBaseConfig")]
    partial class AddBaseConfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StudentAffairs.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("char(100)");

                    b.Property<int?>("CreaditHours")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<Guid>("InstructorId")
                        .HasColumnType("char(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumberOfStudents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid?>("PreRequest")
                        .HasColumnType("char(100)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.HasIndex("Name");

                    b.HasIndex("PreRequest");

                    b.ToTable("Courses", null, t =>
                        {
                            t.HasCheckConstraint("CK_Creadit_Hours", "`CreaditHours` >= 0 AND `CreaditHours` <= 4");
                        });
                });

            modelBuilder.Entity("StudentAffairs.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("char(100)");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasDefaultValue(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("StudentAffairs.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("char(100)");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasDefaultValue(18);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<float?>("GPA")
                        .HasPrecision(3, 2)
                        .HasColumnType("float");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.ToTable("Students", null, t =>
                        {
                            t.HasCheckConstraint("CK_Student_GPA", "`GPA` >= 0 AND `GPA` <= 4");
                        });
                });

            modelBuilder.Entity("StudentAffairs.Course", b =>
                {
                    b.HasOne("StudentAffairs.Doctor", null)
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentAffairs.Course", null)
                        .WithMany()
                        .HasForeignKey("PreRequest")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
