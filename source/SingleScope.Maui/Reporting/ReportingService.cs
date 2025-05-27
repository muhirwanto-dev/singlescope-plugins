using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Reporting.Enums;
using SingleScope.Maui.Reporting.Options;

namespace SingleScope.Maui.Reporting
{
    public class ReportingService<T> : IReportingService<T>
    {
        private readonly ReportingOptions _options;
        private readonly ILogger<T> _logger;
        private readonly IDialogService _dialogService;

        public ReportingService(IOptions<ReportingOptions> options, ILogger<T> logger, IDialogService dialogService)
        {
            _options = options.Value;
            _logger = logger;
            _dialogService = dialogService;
        }

        public void Report(Exception exception, string? message = null)
        {
            _ = ReportAsync(exception, message);
        }

        public async Task ReportAsync(Exception exception, string? message = null)
        {
            StringBuilder sb = new();

            if (!string.IsNullOrEmpty(message))
            {
                sb.AppendLine(message);
                sb.AppendLine("---> Original stack trace:");
            }

            ReportingMode mode = _options.ReportingMode;

            if ((mode & ReportingMode.EnableExceptionStackTrace) != 0)
            {
                sb.AppendLine(exception.ToString());
            }
            else
            {
                sb.Append(exception.Message);
            }

            // build the dialog message before adding the stack trace, so that it doesn't get included in the dialog message.
            string dialogMessage = sb.ToString();

            if ((mode & ReportingMode.EnableLogging) != 0)
            {
                // For logging, always add exception stack trace to the output.
                if ((mode & ReportingMode.EnableExceptionStackTrace) == 0)
                {
                    sb.AppendLine(exception.StackTrace);
                }

                _logger.LogError(sb.ToString());
            }

            if ((mode & ReportingMode.EnableErrorDialog) != 0)
            {
                await _dialogService.ShowErrorDialogAsync(dialogMessage);
            }
        }
    }
}
