using amsAPI.Middleware;
using amsAPI.Repositories.AssetRepository;
using amsAPI.Repositories.AssignmentRepository;
using amsAPI.Repositories.EmployeeRepository;
using amsAPI.Repositories.ReferenceDataRepository.BrandRepository;
using amsAPI.Repositories.ReferenceDataRepository.CategoryRepository;
using amsAPI.Repositories.ReferenceDataRepository.FeatureRepository;
using amsAPI.Repositories.ReferenceDataRepository.LocationRepository;
using amsAPI.Services.AssignmentServ;
using amsAPI.Services.EmployeeServ;
using amsAPI.Services.ReferenceDataServices;
using Domain.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Assets;
using Services.DbTransactionManager;


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
    options.UseSqlite(connectionString));

// Repository & Service Registrations
builder.Services.AddScoped<IAssetRepo, AssetRepo>();
builder.Services.AddScoped<AssetService>();

builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
builder.Services.AddScoped<AssignmentService>();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped< EmployeeService>();


builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<ILocationRepo,LocationRepo>();
builder.Services.AddScoped<IBrandRepo, BrandRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IFeatureRepo, FeatureRepo>();

builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<FeatureService>();





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
