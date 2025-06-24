using amsAPI.Middleware;
using amsAPI.Repositories.AssetRepository;
using amsAPI.Repositories.AssignmentRepository;
using amsAPI.Repositories.EmployeeRepository;
using amsAPI.Repositories.GenericRepository;
using amsAPI.Services.AssignmentServ;
using amsAPI.Services.EmployeeServ;
using Domain.Data;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Services.Assets;
using Services.DbTransactionManager;
using Services.ReferenceData;
using Services.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Env.Load();
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<amsDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<IAssetRepo, AssetRepo>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IReferenceDataService,ReferenceDataService>();
builder.Services.AddScoped<IAssignmentRepo, AssignmentRepo>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();



app.Run();
