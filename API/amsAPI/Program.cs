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
builder.Services.AddScoped<IReferenceDataService, ReferenceDataService>();

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
