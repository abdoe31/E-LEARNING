using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class final4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerFilePath",
                table: "Assighment",
                newName: "Header");

            migrationBuilder.AddColumn<string>(
                name: "UserAnswerFilePath",
                table: "UserAssighment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelAnswerFilePath",
                table: "Assighment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAnswerFilePath",
                table: "UserAssighment");

            migrationBuilder.DropColumn(
                name: "ModelAnswerFilePath",
                table: "Assighment");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "Assighment",
                newName: "AnswerFilePath");
        }
    }
}
