using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Enums;
using SingleScope.Reporting.Models;

namespace SingleScope.Reporting.Logging.Sinks
{
    /// <summary>
    /// Report sink that forwards reports to Microsoft.Extensions.Logging.
    /// </summary>
    public sealed class LoggerReportSink : IReportSink
    {
        private readonly ILogger<LoggerReportSink> _logger;

        public LoggerReportSink(ILogger<LoggerReportSink> logger)
        {
            _logger = logger;
        }

        public bool CanHandle(ReportingMode mode, Report report)
        {
            return true;
        }

        public Task HandleAsync(ReportingMode mode, Report report, CancellationToken cancellationToken)
        {
            var message = report.Message;

            if (mode.HasFlag(ReportingMode.IncludeStackTrace))
            {
                _logger.Log(
                    MapSeverity(report.Severity),
                    report.Exception,
                    message);
            }
            else
            {
                _logger.Log(
                    MapSeverity(report.Severity),
                    message);
            }

            return Task.CompletedTask;
        }

        private static LogLevel MapSeverity(ReportSeverity severity) =>
            severity switch
            {
                ReportSeverity.Trace => LogLevel.Trace,
                ReportSeverity.Information => LogLevel.Information,
                ReportSeverity.Warning => LogLevel.Warning,
                ReportSeverity.Error => LogLevel.Error,
                ReportSeverity.Critical => LogLevel.Critical,
                _ => LogLevel.Error
            };
    }
}
