using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class coordinatesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "BuildingFloors",
                newName: "FloorEnum");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "BuildingFloors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "Building",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "BuildingFloors");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Building");

            migrationBuilder.RenameColumn(
                name: "FloorEnum",
                table: "BuildingFloors",
                newName: "Floor");
        }
    }
}
