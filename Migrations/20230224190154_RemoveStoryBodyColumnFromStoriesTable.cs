using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStoryBodyColumnFromStoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryBody",
                table: "StoriesTable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StoryBody",
                table: "StoriesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
