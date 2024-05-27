using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumForGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class privatemessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reported",
                table: "PrivateMessage");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "PrivateMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReciverId",
                table: "PrivateMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PrivateMessage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "PrivateMessage");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "PrivateMessage",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ReciverId",
                table: "PrivateMessage",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Reported",
                table: "PrivateMessage",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
