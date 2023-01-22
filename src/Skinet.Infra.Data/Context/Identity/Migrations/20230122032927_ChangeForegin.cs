using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skinet.Infra.Data.Context.Identity.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForegin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AddressId",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "AppUserId",
                table: "Address",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AppUserId",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "AddressId",
                table: "Address",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
