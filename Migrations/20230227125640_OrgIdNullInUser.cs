using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSence.Migrations
{
    /// <inheritdoc />
    public partial class OrgIdNullInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_organization_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_organization_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_organization_OrganizationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<long>(
                name: "OrganizationId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_organization_OrganizationId",
                table: "AspNetUsers",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
