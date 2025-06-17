using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thumanya.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostForiengKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authers_AutherId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AutherId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AutherId",
                table: "Posts");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authers_AuthorId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "AutherId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutherId",
                table: "Posts",
                column: "AutherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authers_AutherId",
                table: "Posts",
                column: "AutherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
