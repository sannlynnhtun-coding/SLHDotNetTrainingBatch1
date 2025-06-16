// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ILogger logger = new Serilog(EnumLogLevel.Info);
try
{
    int a = 1;
    int b = 0;
    logger.LogDebug($"a value => {a}");
    logger.LogDebug($"b value => {b}");
    int result = a / b;
    logger.LogDebug($"result value => {result}");
}
catch (Exception ex)
{
    logger.LogError($"Error {ex.ToString()}");
}

public interface ILogger
{
    void LogFatal(string message);
    void LogError(string message);
    void LogWarn(string message);
    void LogInfo(string message);
    void LogDebug(string message);
    void LogTrace(string message);
}

public enum EnumLogLevel
{
    Fatal,
    Error,
    Warn,
    Info,
    Debug,
    Trace
}

public class Serilog : ILogger
{
    private readonly EnumLogLevel _logLevel;
    public Serilog(EnumLogLevel logLevel)
    {
        _logLevel = logLevel;
    }

    public void LogDebug(string message)
    {
        if (_logLevel== EnumLogLevel.Debug ||
            (int)_logLevel >= 4)
            Console.WriteLine($"Serilog - DEBUG : {message}");
    }

    public void LogError(string message)
    {
        if (_logLevel== EnumLogLevel.Error ||
            (int)_logLevel >= 1)
            Console.WriteLine($"Serilog - ERROR : {message}");
    }

    public void LogFatal(string message)
    {
        if (_logLevel== EnumLogLevel.Fatal ||
            (int)_logLevel <= 5)
            Console.WriteLine($"Serilog - FATAL : {message}");
    }

    public void LogInfo(string message)
    {
        if (_logLevel== EnumLogLevel.Info ||
            (int)_logLevel >= 3)
            Console.WriteLine($"Serilog - INFO : {message}");
    }

    public void LogTrace(string message)
    {
        if (_logLevel== EnumLogLevel.Debug ||
            (int)_logLevel >= 5)
            Console.WriteLine($"Serilog - TRACE : {message}");
    }

    public void LogWarn(string message)
    {
        if (_logLevel== EnumLogLevel.Warn ||
            (int)_logLevel >= 2)
            Console.WriteLine($"Serilog - WARN : {message}");
    }
}

public class NLog : ILogger
{
    public void LogDebug(string message)
    {
        Console.WriteLine($"NLog - DEBUG : {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"NLog - ERROR : {message}");
    }

    public void LogFatal(string message)
    {
        Console.WriteLine($"NLog - FATAL : {message}");
    }

    public void LogInfo(string message)
    {
        Console.WriteLine($"NLog - INFO : {message}");
    }

    public void LogTrace(string message)
    {
        Console.WriteLine($"NLog - TRACE : {message}");
    }

    public void LogWarn(string message)
    {
        Console.WriteLine($"NLog - WARN : {message}");
    }
}

public class Log4net : ILogger
{
    public void LogDebug(string message)
    {
        Console.WriteLine($"Log4net - DEBUG : {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"Log4net - ERROR : {message}");
    }

    public void LogFatal(string message)
    {
        Console.WriteLine($"Log4net - FATAL : {message}");
    }

    public void LogInfo(string message)
    {
        Console.WriteLine($"Log4net - INFO : {message}");
    }

    public void LogTrace(string message)
    {
        Console.WriteLine($"Log4net - TRACE : {message}");
    }

    public void LogWarn(string message)
    {
        Console.WriteLine($"Log4net - WARN : {message}");
    }
}
