using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class AddFloor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "deviceinfo_houseid_fkey",
                table: "device_info");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "device_info");

            migrationBuilder.RenameColumn(
                name: "houseid",
                table: "device_info",
                newName: "BuildingFloorId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "device_info",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BuildingFloor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFloor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingFloor_house_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "house",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingFloor_BuildingId",
                table: "BuildingFloor",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_device_info_BuildingFloor_BuildingFloorId",
                table: "device_info",
                column: "BuildingFloorId",
                principalTable: "BuildingFloor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_info_BuildingFloor_BuildingFloorId",
                table: "device_info");

            migrationBuilder.DropTable(
                name: "BuildingFloor");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "device_info");

            migrationBuilder.RenameColumn(
                name: "BuildingFloorId",
                table: "device_info",
                newName: "houseid");


            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "device_info",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "deviceinfo_houseid_fkey",
                table: "device_info",
                column: "houseid",
                principalTable: "house",
                principalColumn: "id");
        }
    }
}
