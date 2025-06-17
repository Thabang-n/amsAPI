using Domain.Data;
using DotNetEnv;



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories.AssetRepository;
using Repositories.GenericRepository;
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
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IReferenceDataService,ReferenceDataService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();



app.Run();
