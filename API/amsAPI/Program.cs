using amsAPI.Middleware;
using amsAPI.Repositories.AssetRepository;
using amsAPI.Repositories.AssignmentRepository;
using amsAPI.Repositories.EmployeeRepository;
using amsAPI.Repositories.GenericRepository;
using amsAPI.Services.AssignmentServ;
using amsAPI.Services.EmployeeServ;
using Domain.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services.Assets;
using Services.DbTransactionManager;
using Services.ReferenceData;
using Services.Validations;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables
Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("CONNECTION_STRING is not set in the environment variables.");

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
builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();

// Authentication & Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://login.microsoftonline.com/ceecc926-0c8f-48d1-b01b-b17091c7d7f5/v2.0";
        options.Audience = "api://16684db4-e91f-44ac-87ab-42b6455b84cb";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,  // Disable issuer validation temporarily
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "api://16684db4-e91f-44ac-87ab-42b6455b84cb"
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
