using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Models;
using SingleScope.Reporting.Options;

namespace SingleScope.Reporting.Services
{
    /// <summary>
    /// Default implementation of <see cref="IReportingService"/>.
    /// Orchestrates report creation and dispatches reports to registered sinks.
    /// </summary>
    public sealed class ReportingService : IReportingService
    {
        private readonly IEnumerable<IReportSink> _sinks;
        private readonly ReportingOptions _options;

        public ReportingService(
            IEnumerable<IReportSink> sinks,
            IOptions<ReportingOptions> options)
        {
            _sinks = sinks ?? throw new ArgumentNullException(nameof(sinks));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public void Report(Exception exception)
        {
            _ = ReportAsync(exception);
        }

        public void Report(Exception exception, ReportSeverity severity, IReportContext? context = null)
        {
            _ = ReportAsync(exception, severity, context);
        }

        public void Report(Report report)
        {
            _ = ReportAsync(report);
        }

        /// <inheritdoc />
        public Task ReportAsync(
            Exception exception,
            CancellationToken cancellationToken = default)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            return ReportAsync(
                exception,
                ReportSeverity.Error,
                context: null,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task ReportAsync(
            Exception exception,
            ReportSeverity severity,
            IReportContext? context = null,
            CancellationToken cancellationToken = default)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            var report = new Report(
                exception: exception,
                severity: severity,
                context: context);

            return ReportAsync(report, cancellationToken);
        }

        /// <inheritdoc />
        public async Task ReportAsync(
            Report report,
            CancellationToken cancellationToken = default)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            foreach (var sink in _sinks)
            {
                if (!sink.CanHandle(_options.Mode, report))
                    continue;

                try
                {
                    await sink.HandleAsync(_options.Mode, report, cancellationToken)
                              .ConfigureAwait(false);
                }
                catch
                {
                    // ⚠️ IMPORTANT:
                    // Reporting must NEVER throw.
                    // Sink failures should not crash the application.
                    //
                    // Intentionally swallowed.
                    // If needed, add a fallback sink for internal diagnostics.
                }
            }
        }
    }
}
