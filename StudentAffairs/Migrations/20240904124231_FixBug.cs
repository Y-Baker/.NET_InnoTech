using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAffairs.Migrations
{
    /// <inheritdoc />
    public partial class FixBug : Migration
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
                oldType: "char(5)",
                oldMaxLength: 5)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Doctors",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Doctors",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(5)",
                oldMaxLength: 5)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
