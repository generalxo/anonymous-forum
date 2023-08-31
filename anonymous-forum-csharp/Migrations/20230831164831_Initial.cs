using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace anonymous_forum_csharp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "General discussion", "General" },
                    { 2, "News and announcements", "News" },
                    { 3, "Help and support", "Help" },
                    { 4, "Suggestions and feedback", "Suggestions" },
                    { 5, "Off-topic discussion", "Off-Topic" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Text", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, "Welcome to Anonymous Forum! Feel free to post anything you want here. Just remember to follow the rules.", "Welcome to Anonymous Forum!", 1 },
                    { 2, "1. Be respectful to others. 2. No spamming. 3. No NSFW content. 4. No advertising. 5. No illegal content.", "Rules", 2 },
                    { 3, "To post, simply click on the \"New Post\" button on the top right corner of the page. You can also reply to other posts by clicking on the \"Reply\" button.", "How to post", 3 },
                    { 4, "You can format your post using Markdown.", "How to format your post", 4 },
                    { 5, "You can format your post using Markdown.", "How to format your post", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
