using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsAffairsWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameStudentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_students",
                table: "tbl_students");

            migrationBuilder.RenameTable(
                name: "tbl_students",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "tbl_students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_students",
                table: "tbl_students",
                column: "Id");
        }
    }
}
