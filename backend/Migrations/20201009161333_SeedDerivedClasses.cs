using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SeedDerivedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TaxBonus",
                table: "Upgrades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DefenseBonus",
                table: "Upgrades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CoralBonus",
                table: "Upgrades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttackBonus",
                table: "Upgrades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MudTractor_CoralBonus",
                table: "Upgrades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UndergroundMartialArts_AttackBonus",
                table: "Upgrades",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UndergroundMartialArts_DefenseBonus",
                table: "Upgrades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Upgrades",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Units",
                table: "Buildings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Buildings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CoralPerTurn",
                table: "Buildings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Buildings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discriminator", "Image", "StatImage" },
                values: new object[] { "FlowController", "img/undersea_game-05.png", "svg/castle-building.svg" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Discriminator",
                value: "ReefCastle");

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 6,
                column: "Discriminator",
                value: "Alchemy");

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Discriminator",
                value: "CoralWall");

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Discriminator",
                value: "MudCombine");

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discriminator", "MudTractor_CoralBonus" },
                values: new object[] { "MudTractor", 10 });

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 4,
                column: "Discriminator",
                value: "SonarCannon");

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Discriminator", "UndergroundMartialArts_AttackBonus", "UndergroundMartialArts_DefenseBonus" },
                values: new object[] { "UndergroundMartialArts", 10, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MudTractor_CoralBonus",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "UndergroundMartialArts_AttackBonus",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "UndergroundMartialArts_DefenseBonus",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Upgrades");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Buildings");

            migrationBuilder.AlterColumn<int>(
                name: "AttackBonus",
                table: "Upgrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoralBonus",
                table: "Upgrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DefenseBonus",
                table: "Upgrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxBonus",
                table: "Upgrades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Units",
                table: "Buildings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Buildings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoralPerTurn",
                table: "Buildings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Image", "StatImage" },
                values: new object[] { "img/undersea_game-07.png", "svg/control-building.svg" });

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoralBonus",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Upgrades",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttackBonus", "DefenseBonus" },
                values: new object[] { 10, 10 });
        }
    }
}
