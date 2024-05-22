using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumForGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_ArchiveFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "SubCategory",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Post",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "MainCategory",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "MainCategory");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
