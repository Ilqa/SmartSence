using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class deviceTypeinDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypeColumns_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeColumns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypeColumns",
                table: "DeviceTypeColumns");

            migrationBuilder.DropColumn(
                name: "Devicetype",
                table: "DeviceInfos");

            migrationBuilder.RenameTable(
                name: "DeviceTypeColumns",
                newName: "DeviceTypeMetaData");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceTypeColumns_DeviceTypeId",
                table: "DeviceTypeMetaData",
                newName: "IX_DeviceTypeMetaData_DeviceTypeId");

            migrationBuilder.AddColumn<long>(
                name: "DeviceTypeId",
                table: "DeviceInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypeMetaData",
                table: "DeviceTypeMetaData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceInfos_DeviceTypeId",
                table: "DeviceInfos",
                column: "DeviceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceInfos_DeviceTypes_DeviceTypeId",
                table: "DeviceInfos",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypeMetaData_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeMetaData",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeviceInfos_DeviceTypes_DeviceTypeId",
                table: "DeviceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceTypeMetaData_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeMetaData");

            migrationBuilder.DropIndex(
                name: "IX_DeviceInfos_DeviceTypeId",
                table: "DeviceInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceTypeMetaData",
                table: "DeviceTypeMetaData");

            migrationBuilder.DropColumn(
                name: "DeviceTypeId",
                table: "DeviceInfos");

            migrationBuilder.RenameTable(
                name: "DeviceTypeMetaData",
                newName: "DeviceTypeColumns");

            migrationBuilder.RenameIndex(
                name: "IX_DeviceTypeMetaData_DeviceTypeId",
                table: "DeviceTypeColumns",
                newName: "IX_DeviceTypeColumns_DeviceTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Devicetype",
                table: "DeviceInfos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceTypeColumns",
                table: "DeviceTypeColumns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypeColumns_DeviceTypes_DeviceTypeId",
                table: "DeviceTypeColumns",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id");
        }
    }
}
