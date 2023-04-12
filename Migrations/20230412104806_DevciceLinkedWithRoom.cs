using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class DevciceLinkedWithRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceInfos_BuildingFloors_BuildingFloorId",
                table: "DeviceInfos");

            migrationBuilder.DropIndex(
                name: "IX_DeviceInfos_BuildingFloorId",
                table: "DeviceInfos");

            migrationBuilder.DropColumn(
                name: "BuildingFloorId",
                table: "DeviceInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BuildingFloorId",
                table: "DeviceInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceInfos_BuildingFloorId",
                table: "DeviceInfos",
                column: "BuildingFloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceInfos_BuildingFloors_BuildingFloorId",
                table: "DeviceInfos",
                column: "BuildingFloorId",
                principalTable: "BuildingFloors",
                principalColumn: "Id");
        }
    }
}
