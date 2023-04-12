using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class RoomCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFloor_Houses_BuildingId",
                table: "BuildingFloor");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceInfos_BuildingFloor_BuildingFloorId",
                table: "DeviceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Blocks_Blockid",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Houses",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingFloor",
                table: "BuildingFloor");

            migrationBuilder.RenameTable(
                name: "Houses",
                newName: "Building");

            migrationBuilder.RenameTable(
                name: "BuildingFloor",
                newName: "BuildingFloors");

            migrationBuilder.RenameIndex(
                name: "IX_Houses_Blockid",
                table: "Building",
                newName: "IX_Building_Blockid");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingFloor_BuildingId",
                table: "BuildingFloors",
                newName: "IX_BuildingFloors_BuildingId");

            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "DeviceInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingFloors",
                table: "BuildingFloors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BuildingFloorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BuildingFloors_BuildingFloorId",
                        column: x => x.BuildingFloorId,
                        principalTable: "BuildingFloors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceInfos_RoomId",
                table: "DeviceInfos",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingFloorId",
                table: "Rooms",
                column: "BuildingFloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Blocks_Blockid",
                table: "Building",
                column: "Blockid",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFloors_Building_BuildingId",
                table: "BuildingFloors",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceInfos_BuildingFloors_BuildingFloorId",
                table: "DeviceInfos",
                column: "BuildingFloorId",
                principalTable: "BuildingFloors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceInfos_Rooms_RoomId",
                table: "DeviceInfos",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Blocks_Blockid",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingFloors_Building_BuildingId",
                table: "BuildingFloors");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceInfos_BuildingFloors_BuildingFloorId",
                table: "DeviceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceInfos_Rooms_RoomId",
                table: "DeviceInfos");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_DeviceInfos_RoomId",
                table: "DeviceInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingFloors",
                table: "BuildingFloors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "DeviceInfos");

            migrationBuilder.RenameTable(
                name: "BuildingFloors",
                newName: "BuildingFloor");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Houses");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingFloors_BuildingId",
                table: "BuildingFloor",
                newName: "IX_BuildingFloor_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_Blockid",
                table: "Houses",
                newName: "IX_Houses_Blockid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingFloor",
                table: "BuildingFloor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Houses",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingFloor_Houses_BuildingId",
                table: "BuildingFloor",
                column: "BuildingId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceInfos_BuildingFloor_BuildingFloorId",
                table: "DeviceInfos",
                column: "BuildingFloorId",
                principalTable: "BuildingFloor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Blocks_Blockid",
                table: "Houses",
                column: "Blockid",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
