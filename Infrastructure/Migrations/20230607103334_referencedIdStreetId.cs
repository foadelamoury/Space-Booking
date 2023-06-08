using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class referencedIdStreetId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.CreateIndex(
                name: "IX_Users_StreetId",
                table: "Users",
                column: "StreetId");
            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_Id",
                table: "Users",
                column: "StreetId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
         name: "FK_Users_Countries_Id",
         table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StreetId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "Users");
        }
    }
}
