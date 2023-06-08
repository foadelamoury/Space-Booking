using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class referencedIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
            type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
           name: "UserId",
           table: "PhoneNumbers",
           type: "bigint",
           nullable: false,
           defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumbers",
                column: "UserId");
            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Users_Id",
                table: "PhoneNumbers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

     


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropForeignKey(
          name: "FK_PhoneNumbers_Users_Id",
          table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PhoneNumbers");
        }
    }
}
