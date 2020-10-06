using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class nameForEveryone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Units",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");
        }
    }
}
