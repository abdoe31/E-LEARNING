using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Classes_Classid",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_Classid",
                table: "Notifications",
                newName: "IX_Notifications_Classid");

            migrationBuilder.AddColumn<int>(
                name: "AcessType",
                table: "UserLecture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Yearid",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Classes_Classid",
                table: "Notifications",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Classes_Classid",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AcessType",
                table: "UserLecture");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_Classid",
                table: "Notification",
                newName: "IX_Notification_Classid");

            migrationBuilder.AlterColumn<int>(
                name: "Yearid",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Classes_Classid",
                table: "Notification",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
