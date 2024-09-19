using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAffairs.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Students",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(100)",
                oldMaxLength: 100)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PreRequest",
                table: "Courses",
                type: "char(100)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "Courses",
                type: "char(100)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "char(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(100)",
                oldMaxLength: 100)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "PreRequest",
                table: "Courses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(100)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "Courses",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(100)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Courses",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(100)",
                oldMaxLength: 100)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
