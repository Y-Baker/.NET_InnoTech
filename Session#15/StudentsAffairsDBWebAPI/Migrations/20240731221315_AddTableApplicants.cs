using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsAffairsWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTableApplicants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Age",
                table: "Students",
                type: "tinyint",
                maxLength: 2,
                nullable: false,
                defaultValue: (byte)18,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 2);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 18),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_Name",
                table: "Applicants",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.AlterColumn<byte>(
                name: "Age",
                table: "Students",
                type: "tinyint",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 2,
                oldDefaultValue: (byte)18);
        }
    }
}
