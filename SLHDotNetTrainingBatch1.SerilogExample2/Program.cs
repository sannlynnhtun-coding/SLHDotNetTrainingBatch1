using Serilog;
using Serilog.Sinks.MSSqlServer;

string folderPath = AppDomain.CurrentDomain.BaseDirectory;
string filePath = Path.Combine(folderPath, "logs/myapp.txt");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(filePath, rollingInterval: RollingInterval.Hour)
            .WriteTo
                .MSSqlServer(
                    connectionString: "Server=.;Database=DotNetTrainingBatch1;User ID=sa;Password=sasa@123;TrustServerCertificate=True;",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_LogEvents", AutoCreateSqlTable = true })
            .CreateLogger();
try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog();

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}