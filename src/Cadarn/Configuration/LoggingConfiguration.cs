using Serilog.Events;

namespace Cadarn.Configuration;

public record LoggingConfiguration
{
    public string LogFileName { get; init; } = null!;

    public long LimitBytes { get; init; }

    public LogEventLevel DefaultLogLevel { get; init; }

    public LogEventLevel MicrosoftLogLevel { get; init; }
}