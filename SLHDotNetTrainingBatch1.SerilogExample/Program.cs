﻿using Serilog;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Hour)
            .WriteTo
                .MSSqlServer(
                    connectionString: "Server=.;Database=DotNetTrainingBatch1;User ID=sa;Password=sasa@123;TrustServerCertificate=True;",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_LogEvents", AutoCreateSqlTable = true })
            .CreateLogger();

Log.Information("Hello, world!");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}
