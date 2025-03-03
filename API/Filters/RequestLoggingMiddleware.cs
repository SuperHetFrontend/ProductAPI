using System.Diagnostics;

namespace API.Filters;

/// <summary>
/// Middleware for logging incoming requests.
/// </summary>
public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        string? method = context.Request.Method;
        string? baseUrl = $"{context.Request.Scheme}://{context.Request.Host}";
        string? fullUrl = $"{baseUrl}{context.Request.Path}{context.Request.QueryString}";

        _logger.LogInformation($"INCOMING Request: {method} {fullUrl}");

        await _next(context);

        stopwatch.Stop();
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

        _logger.LogInformation($"COMPLETED Request: {method} {fullUrl} - {elapsedMilliseconds}ms");
    }
}
