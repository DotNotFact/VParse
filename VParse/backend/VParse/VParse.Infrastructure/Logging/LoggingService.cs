using Microsoft.Extensions.Logging;

namespace VParse.Infrastructure.Logging;

public class LoggingService(ILogger<LoggingService> logger)
{
    private readonly ILogger<LoggingService> _logger = logger;

    public void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    public void LogError(Exception ex, string message)
    {
        _logger.LogError(ex, message);
    }
}
