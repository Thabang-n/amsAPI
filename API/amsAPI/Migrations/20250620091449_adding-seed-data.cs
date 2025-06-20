using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace amsAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Dell" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "HP" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Lenovo" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Laptop" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Monitor" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "IsAdmin", "Username" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "superman@example.com", true, "superman_admin" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "batman@example.com", false, "batman_admin" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "jane@example.com", false, "jane_smith" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "mike@example.com", false, "mike_brown" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationAddress", "LocationCity", "LocationName", "LocationState" },
                values: new object[,]
                {
                    { new Guid("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510"), "123 Sandton Street", "Sandton", "Head Office", "Gauteng" },
                    { new Guid("44c89c93-376a-4233-a3ed-dfdab5c26515"), "202 Bhopal Street", "Bhopal", "Delivery Centre - Bhopal", "Madhya Pradesh" },
                    { new Guid("5e2cfa0b-1993-456e-910f-cc30be034f32"), "789 Hyderabad Lane", "Hyderabad", "Delivery Centre - Hyderabad", "Telangana" },
                    { new Guid("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0"), "456 Bhilai Road", "Bhilai", "India Headquarters", "Chhattisgarh" },
                    { new Guid("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0"), "101 Pune Blvd", "Pune", "Delivery Centre - Pune", "Maharashtra" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "FeatureId", "CategoryId", "FeatureKey" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-1234-1234-123456789abc"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Battery Life" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("66666666-6666-6666-6666-666666666666"), "RAM" },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new Guid("77777777-7777-7777-7777-777777777777"), "Screen Size" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("12345678-1234-1234-1234-123456789abc"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "FeatureId",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("44c89c93-376a-4233-a3ed-dfdab5c26515"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("5e2cfa0b-1993-456e-910f-cc30be034f32"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));
        }
    }
}
