using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amsAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Maintenances",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Maintenances_LocationId",
                table: "Maintenances",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maintenances_Locations_LocationId",
                table: "Maintenances",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maintenances_Locations_LocationId",
                table: "Maintenances");

            migrationBuilder.DropIndex(
                name: "IX_Maintenances_LocationId",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Maintenances");
        }
    }
}
