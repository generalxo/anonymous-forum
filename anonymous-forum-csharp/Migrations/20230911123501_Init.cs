using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace anonymous_forum_csharp.Migrations
{
    public partial class Init : Migration
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
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
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
                columns: new[] { "Id", "IpAdress", "Text", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, "::1", "1. Be respectful to others. 2. No spamming. 3. No NSFW content. 4. No advertising. 5. No illegal content.", "Forum rules", 1 },
                    { 2, "::1", "On 24 February 2022, Russia invaded Ukraine in an escalation of the Russo-Ukrainian War which began in 2014.", "Ukraine war", 2 },
                    { 3, "::1", "Before you start, make sure you find a safe place to park. It’s better to drive further and risk damaging the wheel rim than stop somewhere dangerous – such as on a narrow road.", "How to change a tire", 3 },
                    { 4, "::1", "I would like you to add sports topic so we can discuss F1!!", "Add sports topic", 4 },
                    { 5, "::1", "A lucid dream is a type of dream in which the dreamer becomes aware that they are dreaming while dreaming.", "Lucid dreams", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "IpAdress", "PostId", "Text" },
                values: new object[] { 1, "::1", 1, "First (comment)!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "IpAdress", "PostId", "Text" },
                values: new object[] { 2, "::1", 2, "Rickard was here" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
