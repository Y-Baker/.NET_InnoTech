using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAffairs.Migrations
{
    /// <inheritdoc />
    public partial class Initiate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(5)", maxLength: 5, nullable: false, collation: "ascii_general_ci"),
                    Mobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 18)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(5)", maxLength: 5, nullable: false, collation: "ascii_general_ci"),
                    Mobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GPA = table.Column<float>(type: "float", precision: 3, scale: 2, nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 18)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.CheckConstraint("CK_Student_GPA", "`GPA` >= 0 AND `GPA` <= 4");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Name",
                table: "Doctors",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
