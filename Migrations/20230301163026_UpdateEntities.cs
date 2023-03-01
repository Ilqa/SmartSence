using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "sector");

            migrationBuilder.DropColumn(
                name: "noofdevices",
                table: "sector");

            migrationBuilder.DropColumn(
                name: "noofgateways",
                table: "sector");

            migrationBuilder.DropColumn(
                name: "coordinates",
                table: "house");

            migrationBuilder.DropColumn(
                name: "noofdevices",
                table: "house");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "device_info");

            migrationBuilder.DropColumn(
                name: "logo",
                table: "block");

            migrationBuilder.DropColumn(
                name: "noofdevices",
                table: "block");

            migrationBuilder.DropColumn(
                name: "noofgateways",
                table: "block");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "device_info",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "device_info");

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "sector",
                type: "character(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "noofdevices",
                table: "sector",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "noofgateways",
                table: "sector",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "coordinates",
                table: "house",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "noofdevices",
                table: "house",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<BitArray>(
                name: "isactive",
                table: "device_info",
                type: "bit(1)",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "logo",
                table: "block",
                type: "character(50)",
                fixedLength: true,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "noofdevices",
                table: "block",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "noofgateways",
                table: "block",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
