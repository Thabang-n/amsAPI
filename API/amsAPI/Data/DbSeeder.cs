

using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.EmployeeModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Microsoft.EntityFrameworkCore;

namespace amsAPI.Data
{
    public static class DbSeeder
    {
        // --- Static GUIDs ---
        // Brands
        public static readonly Guid BrandDellId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid BrandHPId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public static readonly Guid BrandLenovoId = Guid.Parse("99999999-9999-9999-9999-999999999999");
        public static readonly Guid BrandAppleId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        // Employees
        public static readonly Guid EmployeeAdminId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        public static readonly Guid EmployeeJohnId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        public static readonly Guid EmployeeJaneId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        public static readonly Guid EmployeeMikeId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        // Locationsa
        public static readonly Guid LocationHeadOfficeId = Guid.Parse("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510");
        public static readonly Guid LocationIndiaHQId = Guid.Parse("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0");
        public static readonly Guid LocationHyderabadId = Guid.Parse("5e2cfa0b-1993-456e-910f-cc30be034f32");
        public static readonly Guid LocationPuneId = Guid.Parse("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0");
        public static readonly Guid LocationBhopalId = Guid.Parse("44c89c93-376a-4233-a3ed-dfdab5c26515");

        // Categories
        public static readonly Guid CategoryLaptopId = Guid.Parse("66666666-6666-6666-6666-666666666666");
        public static readonly Guid CategoryMonitorId = Guid.Parse("77777777-7777-7777-7777-777777777777");
        public static readonly Guid CategoryPhoneId = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

        // Features
        public static readonly Guid FeatureRamId = Guid.Parse("88888888-8888-8888-8888-888888888888");
        public static readonly Guid FeatureScreenSizeId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
        public static readonly Guid FeatureBatteryId = Guid.Parse("12345678-1234-1234-1234-123456789abc");

        public static void Seed(ModelBuilder modelBuilder)
        {
            // Brands
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = BrandDellId, BrandName = "Dell" },
                new Brand { BrandId = BrandHPId, BrandName = "HP" },
                new Brand { BrandId = BrandLenovoId, BrandName = "Lenovo" },
                new Brand { BrandId = BrandAppleId, BrandName = "Apple" }
            );

            // Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = EmployeeAdminId, Username = "superman_admin", Email = "superman@example.com", IsAdmin = true },
                new Employee { EmployeeId = EmployeeJohnId, Username = "batman_admin", Email = "batman@example.com", IsAdmin = false },
                new Employee { EmployeeId = EmployeeJaneId, Username = "jane_smith", Email = "jane@example.com", IsAdmin = false },
                new Employee { EmployeeId = EmployeeMikeId, Username = "mike_brown", Email = "mike@example.com", IsAdmin = false }
            );

            // Locations
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = LocationHeadOfficeId,
                    LocationName = "Head Office",
                    LocationCity = "Sandton",
                    LocationState = "Gauteng",
                    LocationAddress = "123 Sandton Street"
                },
                new Location
                {
                    LocationId = LocationIndiaHQId,
                    LocationName = "India Headquarters",
                    LocationCity = "Bhilai",
                    LocationState = "Chhattisgarh",
                    LocationAddress = "456 Bhilai Road"
                },
                new Location
                {
                    LocationId = LocationHyderabadId,
                    LocationName = "Delivery Centre - Hyderabad",
                    LocationCity = "Hyderabad",
                    LocationState = "Telangana",
                    LocationAddress = "789 Hyderabad Lane"
                },
                new Location
                {
                    LocationId = LocationPuneId,
                    LocationName = "Delivery Centre - Pune",
                    LocationCity = "Pune",
                    LocationState = "Maharashtra",
                    LocationAddress = "101 Pune Blvd"
                },
                new Location
                {
                    LocationId = LocationBhopalId,
                    LocationName = "Delivery Centre - Bhopal",
                    LocationCity = "Bhopal",
                    LocationState = "Madhya Pradesh",
                    LocationAddress = "202 Bhopal Street"
                }
            );

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = CategoryLaptopId, CategoryName = "Laptop" },
                new Category { CategoryId = CategoryMonitorId, CategoryName = "Monitor" },
                new Category { CategoryId = CategoryPhoneId, CategoryName = "Phone" }
            );

            // Features (no navigation properties)
            modelBuilder.Entity<Feature>().HasData(
                new Feature { FeatureId = FeatureRamId, FeatureKey = "RAM", CategoryId = CategoryLaptopId },
                new Feature { FeatureId = FeatureScreenSizeId, FeatureKey = "Screen Size", CategoryId = CategoryMonitorId },
                new Feature { FeatureId = FeatureBatteryId, FeatureKey = "Battery Life", CategoryId = CategoryPhoneId }
            );
        }
    }
}


