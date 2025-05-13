using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.Shared;
using SLHDotNetTrainingBatch1.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "DotNetTrainingBatch1",
//    UserID = "sa",
//    Password = "sasa@123",
//    TrustServerCertificate = true
//};
//builder.Services.AddScoped<IDbV2Service, DapperService>();
builder.Services.AddScoped<IDbV2Service, Dapper2Service>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
