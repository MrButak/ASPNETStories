using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stories.Migrations
{
    /// <inheritdoc />
    public partial class CreateParagraphsAndSetRelationshipWithParagraphsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParagraphsTable",
                columns: table => new
                {
                    ParagraphId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParagraphText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    StoriesTableStoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParagraphsTable", x => x.ParagraphId);
                    table.ForeignKey(
                        name: "FK_ParagraphsTable_StoriesTable_StoriesTableStoryId",
                        column: x => x.StoriesTableStoryId,
                        principalTable: "StoriesTable",
                        principalColumn: "StoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParagraphsTable_StoriesTableStoryId",
                table: "ParagraphsTable",
                column: "StoriesTableStoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParagraphsTable");
        }
    }
}
