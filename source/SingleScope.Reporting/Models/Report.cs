using System;
using SingleScope.Reporting.Abstractions;

namespace SingleScope.Reporting.Models
{
    public sealed class Report
    {
        public Exception Exception { get; }

        public string Message { get; }

        public ReportSeverity Severity { get; }

        public DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;

        public IReportContext? Context { get; }

        public Report(
            Exception exception,
            string? message = null,
            ReportSeverity severity = ReportSeverity.Error,
            IReportContext? context = null)
        {
            Exception = exception;
            Message = message ?? exception.Message;
            Severity = severity;
            Context = context;
        }
    }
}
