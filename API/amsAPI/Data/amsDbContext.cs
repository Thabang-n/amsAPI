
using amsAPI.Data;
using Domain.Models.AssetAttributeModel;
using Domain.Models.AssetModel;
using Domain.Models.AssignmentModel;
using Domain.Models.AuditTrailModel;
using Domain.Models.BrandModel;
using Domain.Models.CategoryModel;
using Domain.Models.EmployeeModel;
using Domain.Models.FeatureModel;
using Domain.Models.LocationModel;
using Domain.Models.MaintenanceModel;
using Domain.Models.RequestModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class amsDbContext:DbContext
    {
        public amsDbContext(DbContextOptions<amsDbContext> options):base(options)
        {
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<AssetAttribute> AssetAttributes { get; set; }
        public DbSet<AssignmentMdl> Assignments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RequestMdl> Requests { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }

    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<AssignmentMdl>()
                .HasOne(a => a.Admin)
                .WithMany(e => e.AdminAssignments)
                .HasForeignKey(a => a.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AssignmentMdl>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.EmployeeAssignments)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                    modelBuilder.Entity<AssetAttribute>()
                .HasOne(aa => aa.Asset)
                .WithMany(a => a.AssetAttributes)
                .HasForeignKey(aa => aa.AssetId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<AssetAttribute>()
                .HasOne(aa => aa.Feature)
                .WithMany(f => f.AssetAttributes)
                .HasForeignKey(aa => aa.FeatureId)
                .OnDelete(DeleteBehavior.Restrict);
           
  
            DbSeeder.Seed(modelBuilder);
        }


    }
}
