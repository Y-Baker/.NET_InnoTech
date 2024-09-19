using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAffairs.Migrations
{
    /// <inheritdoc />
    public partial class AddCreditHourseToCourses : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "CreaditHours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Creadit_Hours",
                table: "Courses",
                sql: "`CreaditHours` >= 0 AND `CreaditHours` <= 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Creadit_Hours",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreaditHours",
                table: "Courses");

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
        }
    }
}
