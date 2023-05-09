using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class deviceUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BlockId",
                table: "Devices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BuildingFloorId",
                table: "Devices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BuildingId",
                table: "Devices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SectorId",
                table: "Devices",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "BuildingFloorId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Devices");
        }
    }
}
