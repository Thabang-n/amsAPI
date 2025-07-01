using amsAPI.mapper;
using amsAPI.Mapper;
using amsAPI.Middleware;
using amsAPI.Repositories.AssetRepository;
using amsAPI.Repositories.AssignmentRepository;
using amsAPI.Repositories.EmployeeRepository;
using amsAPI.Repositories.GenericRepository;
using amsAPI.Repositories.ReferenceData.BrandRepository;
using amsAPI.Repositories.ReferenceData.CategoryRepository;
using amsAPI.Repositories.ReferenceData.FeatureRepository;
using amsAPI.Repositories.ReferenceData.LocationRepository;
using amsAPI.Services.AssignmentServ;
using amsAPI.Services.EmployeeServ;
using amsAPI.Services.ReferenceData;
using Domain.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Assets;
using Services.DbTransactionManager;
using Services.ReferenceData;


var builder = WebApplication.CreateBuilder(args);

// Load environment variables
Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
var authority = Environment.GetEnvironmentVariable("Jwt__Authority");
var audience = Environment.GetEnvironmentVariable("Jwt__Audience");



// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<amsDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository & Service Registrations
builder.Services.AddScoped<IAssetRepo, AssetRepo>();
builder.Services.AddScoped<IAssetService, AssetService>();

builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<ITransactionService, TransactionService>();

//Repos
builder.Services.AddScoped<ILocationRepo, LocationRepo>();
builder.Services.AddScoped<IBrandRepo, BrandRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IFeatureRepo, FeatureRepo>();

//services
builder.Services.AddScoped<BrandReferenceDataService>();
builder.Services.AddScoped<LocationReferenceDataService>();
builder.Services.AddScoped<CategoryReferenceDataService>();
builder.Services.AddScoped<FeatureReferenceDataService>();
//mappers
builder.Services.AddScoped<LocationResponseMapper>();
builder.Services.AddScoped<FeatureResponseMapper>();
builder.Services.AddScoped<BrandResponseMapper>();
builder.Services.AddScoped<CategoriesResponseMapper>();


// Authentication & Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = authority;
        options.Audience = audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,  
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = audience
        };
    });


builder.Services.AddAuthorization();

// Build the app
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
