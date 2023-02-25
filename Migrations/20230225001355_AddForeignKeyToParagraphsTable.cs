using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stories.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToParagraphsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParagraphsTable_StoriesTable_StoriesTableStoryId",
                table: "ParagraphsTable");

            migrationBuilder.DropIndex(
                name: "IX_ParagraphsTable_StoriesTableStoryId",
                table: "ParagraphsTable");

            migrationBuilder.DropColumn(
                name: "StoriesTableStoryId",
                table: "ParagraphsTable");

            migrationBuilder.CreateIndex(
                name: "IX_ParagraphsTable_StoryId",
                table: "ParagraphsTable",
                column: "StoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParagraphsTable_StoriesTable_StoryId",
                table: "ParagraphsTable",
                column: "StoryId",
                principalTable: "StoriesTable",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParagraphsTable_StoriesTable_StoryId",
                table: "ParagraphsTable");

            migrationBuilder.DropIndex(
                name: "IX_ParagraphsTable_StoryId",
                table: "ParagraphsTable");

            migrationBuilder.AddColumn<int>(
                name: "StoriesTableStoryId",
                table: "ParagraphsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParagraphsTable_StoriesTableStoryId",
                table: "ParagraphsTable",
                column: "StoriesTableStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParagraphsTable_StoriesTable_StoriesTableStoryId",
                table: "ParagraphsTable",
                column: "StoriesTableStoryId",
                principalTable: "StoriesTable",
                principalColumn: "StoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
