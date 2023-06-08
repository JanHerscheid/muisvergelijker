using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class adjustuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Mods");

            migrationBuilder.AddColumn<string>(
                name: "auth0Id",
                table: "Mods",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auth0Id",
                table: "Mods");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Mods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
