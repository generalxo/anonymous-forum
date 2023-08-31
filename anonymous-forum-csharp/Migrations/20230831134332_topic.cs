using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace anonymous_forum_csharp.Migrations
{
    public partial class topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenrePosts_Topics_PostId",
                table: "GenrePosts");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenrePosts",
                newName: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_GenrePosts_TopicId",
                table: "GenrePosts",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenrePosts_Topics_TopicId",
                table: "GenrePosts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenrePosts_Topics_TopicId",
                table: "GenrePosts");

            migrationBuilder.DropIndex(
                name: "IX_GenrePosts_TopicId",
                table: "GenrePosts");

            migrationBuilder.RenameColumn(
                name: "TopicId",
                table: "GenrePosts",
                newName: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenrePosts_Topics_PostId",
                table: "GenrePosts",
                column: "PostId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
