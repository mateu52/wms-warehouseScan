using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wmsmagazyn.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedByUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedByUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedByUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedByUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedByUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");
        }
    }
}
