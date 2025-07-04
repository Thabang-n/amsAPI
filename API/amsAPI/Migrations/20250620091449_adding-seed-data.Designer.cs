﻿// <auto-generated />
using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace amsAPI.Migrations
{
    [DbContext(typeof(amsDbContext))]
    [Migration("20250620091449_adding-seed-data")]
    partial class addingseeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AssetAttributeModel.AssetAttribute", b =>
                {
                    b.Property<Guid>("AssetAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AssetAttributeId");

                    b.HasIndex("AssetId");

                    b.HasIndex("FeatureId");

                    b.ToTable("AssetAttributes");
                });

            modelBuilder.Entity("Domain.Models.AssetModel.Asset", b =>
                {
                    b.Property<Guid>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssetId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("LocationId1");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Domain.Models.AssignmentModel.Assignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLinked")
                        .HasColumnType("bit");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AdminId");

                    b.HasIndex("AssetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Domain.Models.AuditTrailModel.AuditTrail", b =>
                {
                    b.Property<Guid>("AuditTrailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuditTrailAction")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PerformedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PerformedByRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("RecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("AuditTrailId");

                    b.HasIndex("PerformedById");

                    b.ToTable("AuditTrails");
                });

            modelBuilder.Entity("Domain.Models.BrandModel.Brand", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = new Guid("11111111-1111-1111-1111-111111111111"),
                            BrandName = "Dell"
                        },
                        new
                        {
                            BrandId = new Guid("22222222-2222-2222-2222-222222222222"),
                            BrandName = "HP"
                        },
                        new
                        {
                            BrandId = new Guid("99999999-9999-9999-9999-999999999999"),
                            BrandName = "Lenovo"
                        },
                        new
                        {
                            BrandId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                            BrandName = "Apple"
                        });
                });

            modelBuilder.Entity("Domain.Models.CategoryModel.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("66666666-6666-6666-6666-666666666666"),
                            CategoryName = "Laptop"
                        },
                        new
                        {
                            CategoryId = new Guid("77777777-7777-7777-7777-777777777777"),
                            CategoryName = "Monitor"
                        },
                        new
                        {
                            CategoryId = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                            CategoryName = "Phone"
                        });
                });

            modelBuilder.Entity("Domain.Models.EmployeeModel.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = new Guid("33333333-3333-3333-3333-333333333333"),
                            Email = "superman@example.com",
                            IsAdmin = true,
                            Username = "superman_admin"
                        },
                        new
                        {
                            EmployeeId = new Guid("44444444-4444-4444-4444-444444444444"),
                            Email = "batman@example.com",
                            IsAdmin = false,
                            Username = "batman_admin"
                        },
                        new
                        {
                            EmployeeId = new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                            Email = "jane@example.com",
                            IsAdmin = false,
                            Username = "jane_smith"
                        },
                        new
                        {
                            EmployeeId = new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                            Email = "mike@example.com",
                            IsAdmin = false,
                            Username = "mike_brown"
                        });
                });

            modelBuilder.Entity("Domain.Models.FeatureModel.Feature", b =>
                {
                    b.Property<Guid>("FeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeatureKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("FeatureId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            FeatureId = new Guid("88888888-8888-8888-8888-888888888888"),
                            CategoryId = new Guid("66666666-6666-6666-6666-666666666666"),
                            FeatureKey = "RAM"
                        },
                        new
                        {
                            FeatureId = new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                            CategoryId = new Guid("77777777-7777-7777-7777-777777777777"),
                            FeatureKey = "Screen Size"
                        },
                        new
                        {
                            FeatureId = new Guid("12345678-1234-1234-1234-123456789abc"),
                            CategoryId = new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                            FeatureKey = "Battery Life"
                        });
                });

            modelBuilder.Entity("Domain.Models.LocationModel.Location", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LocationCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LocationState")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = new Guid("3a1c25c0-6e9e-4cbb-a54d-6f6ce6b6e510"),
                            LocationAddress = "123 Sandton Street",
                            LocationCity = "Sandton",
                            LocationName = "Head Office",
                            LocationState = "Gauteng"
                        },
                        new
                        {
                            LocationId = new Guid("8f1b75ae-7f6d-4f10-89d9-bb3f5cf3e9f0"),
                            LocationAddress = "456 Bhilai Road",
                            LocationCity = "Bhilai",
                            LocationName = "India Headquarters",
                            LocationState = "Chhattisgarh"
                        },
                        new
                        {
                            LocationId = new Guid("5e2cfa0b-1993-456e-910f-cc30be034f32"),
                            LocationAddress = "789 Hyderabad Lane",
                            LocationCity = "Hyderabad",
                            LocationName = "Delivery Centre - Hyderabad",
                            LocationState = "Telangana"
                        },
                        new
                        {
                            LocationId = new Guid("d38ed0cb-7602-4d58-a6fd-8bcf5d504db0"),
                            LocationAddress = "101 Pune Blvd",
                            LocationCity = "Pune",
                            LocationName = "Delivery Centre - Pune",
                            LocationState = "Maharashtra"
                        },
                        new
                        {
                            LocationId = new Guid("44c89c93-376a-4233-a3ed-dfdab5c26515"),
                            LocationAddress = "202 Bhopal Street",
                            LocationCity = "Bhopal",
                            LocationName = "Delivery Centre - Bhopal",
                            LocationState = "Madhya Pradesh"
                        });
                });

            modelBuilder.Entity("Domain.Models.LocationModel.LocationDto", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("LocationDto");
                });

            modelBuilder.Entity("Domain.Models.MaintenanceModel.Maintenance", b =>
                {
                    b.Property<Guid>("MaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaintenanceId");

                    b.HasIndex("AssetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Maintenances");
                });

            modelBuilder.Entity("Domain.Models.RequestModel.RequestMdl", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RequestId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Domain.Models.AssetAttributeModel.AssetAttribute", b =>
                {
                    b.HasOne("Domain.Models.AssetModel.Asset", "Asset")
                        .WithMany("AssetAttributes")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.FeatureModel.Feature", "Feature")
                        .WithMany("AssetAttributes")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("Domain.Models.AssetModel.Asset", b =>
                {
                    b.HasOne("Domain.Models.BrandModel.Brand", "Brand")
                        .WithMany("Assets")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.CategoryModel.Category", "Category")
                        .WithMany("Assets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.LocationModel.LocationDto", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.LocationModel.Location", null)
                        .WithMany("Assets")
                        .HasForeignKey("LocationId1");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Models.AssignmentModel.Assignment", b =>
                {
                    b.HasOne("Domain.Models.EmployeeModel.Employee", "Admin")
                        .WithMany("AdminAssignments")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Models.AssetModel.Asset", "Asset")
                        .WithMany("Assignments")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.EmployeeModel.Employee", "Employee")
                        .WithMany("EmployeeAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Asset");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.AuditTrailModel.AuditTrail", b =>
                {
                    b.HasOne("Domain.Models.EmployeeModel.Employee", "PerformedBy")
                        .WithMany("AuditTrails")
                        .HasForeignKey("PerformedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PerformedBy");
                });

            modelBuilder.Entity("Domain.Models.FeatureModel.Feature", b =>
                {
                    b.HasOne("Domain.Models.CategoryModel.Category", "Category")
                        .WithMany("Features")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.MaintenanceModel.Maintenance", b =>
                {
                    b.HasOne("Domain.Models.AssetModel.Asset", "Asset")
                        .WithMany("Maintenances")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.EmployeeModel.Employee", "Employee")
                        .WithMany("Maintenances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.RequestModel.RequestMdl", b =>
                {
                    b.HasOne("Domain.Models.CategoryModel.Category", "Category")
                        .WithMany("Requests")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.EmployeeModel.Employee", "Employee")
                        .WithMany("Requests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.AssetModel.Asset", b =>
                {
                    b.Navigation("AssetAttributes");

                    b.Navigation("Assignments");

                    b.Navigation("Maintenances");
                });

            modelBuilder.Entity("Domain.Models.BrandModel.Brand", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("Domain.Models.CategoryModel.Category", b =>
                {
                    b.Navigation("Assets");

                    b.Navigation("Features");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Models.EmployeeModel.Employee", b =>
                {
                    b.Navigation("AdminAssignments");

                    b.Navigation("AuditTrails");

                    b.Navigation("EmployeeAssignments");

                    b.Navigation("Maintenances");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Models.FeatureModel.Feature", b =>
                {
                    b.Navigation("AssetAttributes");
                });

            modelBuilder.Entity("Domain.Models.LocationModel.Location", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
