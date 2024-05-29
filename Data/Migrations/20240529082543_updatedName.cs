using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumForGaming.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comment",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Comment",
                newName: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Post",
                type: "bit",
                nullable: true);
        }
    }
}
