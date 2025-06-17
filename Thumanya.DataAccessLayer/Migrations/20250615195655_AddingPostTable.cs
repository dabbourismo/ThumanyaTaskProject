using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thumanya.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddingPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Cover = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AudioUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    VideoUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsPaidContent = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SponsoredBy = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Duration = table.Column<long>(type: "INTEGER", nullable: true),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutherId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChannelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Authers_AutherId",
                        column: x => x.AutherId,
                        principalTable: "Authers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutherId",
                table: "Posts",
                column: "AutherId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ChannelId",
                table: "Posts",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ChannelId_PublishDate",
                table: "Posts",
                columns: new[] { "ChannelId", "PublishDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsPaidContent",
                table: "Posts",
                column: "IsPaidContent");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PublishDate",
                table: "Posts",
                column: "PublishDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
