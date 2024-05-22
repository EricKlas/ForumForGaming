using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumForGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class replayId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplyTo",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "ReplyToId",
                table: "Comment",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplyToId",
                table: "Comment");

            migrationBuilder.AddColumn<string>(
                name: "ReplyTo",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
