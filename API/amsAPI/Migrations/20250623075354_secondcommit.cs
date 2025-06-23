using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amsAPI.Migrations
{
    /// <inheritdoc />
    public partial class secondcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_LocationDto_LocationId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Locations_LocationId1",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "LocationDto");

            migrationBuilder.DropIndex(
                name: "IX_Assets_LocationId1",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "LocationId1",
                table: "Assets");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510"),
                column: "LocationName",
                value: "South africa");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("44c89c93-376a-4233-a3ed-dfdab5c26515"),
                columns: new[] { "LocationName", "LocationState" },
                values: new object[] { "Uk", "London" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("5e2cfa0b-1993-456e-910f-cc30be034f32"),
                column: "LocationName",
                value: "India");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0"),
                column: "LocationName",
                value: "India");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0"),
                column: "LocationName",
                value: "India");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Locations_LocationId",
                table: "Assets");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId1",
                table: "Assets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationDto",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDto", x => x.LocationId);
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510"),
                column: "LocationName",
                value: "Head Office");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("44c89c93-376a-4233-a3ed-dfdab5c26515"),
                columns: new[] { "LocationName", "LocationState" },
                values: new object[] { "Delivery Centre - Bhopal", "Madhya Pradesh" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("5e2cfa0b-1993-456e-910f-cc30be034f32"),
                column: "LocationName",
                value: "Delivery Centre - Hyderabad");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0"),
                column: "LocationName",
                value: "India Headquarters");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0"),
                column: "LocationName",
                value: "Delivery Centre - Pune");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_LocationId1",
                table: "Assets",
                column: "LocationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_LocationDto_LocationId",
                table: "Assets",
                column: "LocationId",
                principalTable: "LocationDto",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Locations_LocationId1",
                table: "Assets",
                column: "LocationId1",
                principalTable: "Locations",
                principalColumn: "LocationId");
        }
    }
}
