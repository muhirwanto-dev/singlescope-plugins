using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Enums;
using SingleScope.Reporting.Models;

namespace SingleScope.Reporting.Maui.Sinks
{
    /// <summary>
    /// MAUI report sink that displays an error dialog to the user.
    /// </summary>
    public sealed class MauiDialogReportSink : IReportSink
    {
        public bool CanHandle(ReportingMode mode, Report report)
        {
            if (mode.HasFlag(ReportingMode.Silent))
                return false;

            if (mode.HasFlag(ReportingMode.Background))
                return false;

            return report.Severity >= ReportSeverity.Error;
        }

        public Task HandleAsync(
            ReportingMode mode,
            Report report,
            CancellationToken cancellationToken)
        {
            var page = Application.Current?.Windows[0].Page;
            var message = mode.HasFlag(ReportingMode.IncludeStackTrace) && report.Exception != null
                ? $"{report.Message}\n\n{report.Exception}"
                : report.Message;

#if NET10_0_OR_GREATER
            return MainThread.InvokeOnMainThreadAsync(() => page?.DisplayAlertAsync(
#else
            return MainThread.InvokeOnMainThreadAsync(() => page?.DisplayAlert(
#endif // NET10_0_OR_GREATER
                "Error",
                message,
                "Ok"
                ));
        }
    }
}
