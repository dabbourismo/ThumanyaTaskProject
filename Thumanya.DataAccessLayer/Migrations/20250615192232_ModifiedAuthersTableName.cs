using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thumanya.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedAuthersTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Authers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authers",
                table: "Authers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authers",
                table: "Authers");

            migrationBuilder.RenameTable(
                name: "Authers",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
