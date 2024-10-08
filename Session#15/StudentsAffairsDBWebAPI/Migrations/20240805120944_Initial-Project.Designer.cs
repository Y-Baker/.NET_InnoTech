﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentsAffairsWebAPI;

#nullable disable

namespace StudentsAffairsWebAPI.Migrations
{
    [DbContext(typeof(StudentsAffairsDbContext))]
    [Migration("20240805120944_Initial-Project")]
    partial class InitialProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StudentsAffairsWebAPI.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasDefaultValue(18);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Applicants", (string)null);
                });

            modelBuilder.Entity("StudentsAffairsWebAPI.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasDefaultValue(18);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("StudentsAffairsWebAPI.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("tinyint unsigned")
                        .HasDefaultValue((byte)18);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("StudentsAffairsWebAPI.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("int")
                        .HasDefaultValue(18);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Teachers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
