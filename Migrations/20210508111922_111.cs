using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzbuzzWeb.Migrations
{
    public partial class _111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculates_AspNetUsers_userId",
                table: "Calculates");

            migrationBuilder.DropIndex(
                name: "IX_Calculates_userId",
                table: "Calculates");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Calculates");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Calculates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Calculates");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Calculates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calculates_userId",
                table: "Calculates",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculates_AspNetUsers_userId",
                table: "Calculates",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
