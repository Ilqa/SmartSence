using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class DeviceTelemtryUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "datetime",
                table: "device_telemetry",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "DeviceEui",
                table: "device_telemetry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceTx",
                table: "device_telemetry",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GatewayRx",
                table: "device_telemetry",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceEui",
                table: "device_telemetry");

            migrationBuilder.DropColumn(
                name: "DeviceTx",
                table: "device_telemetry");

            migrationBuilder.DropColumn(
                name: "GatewayRx",
                table: "device_telemetry");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "datetime",
                table: "device_telemetry",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
