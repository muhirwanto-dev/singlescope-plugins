using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SingleScope.Maui.Dialogs;

namespace SingleScope.Maui.Reports
{
    public class ReportService<T> : IReportService<T>
    {
        private readonly ReportOptions _options;
        private readonly ILogger<T> _logger;
        private readonly IDialogService _dialogService;

        public ReportService(IOptions<ReportOptions> options, ILogger<T> logger, IDialogService dialogService)
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
            if (!string.IsNullOrEmpty(message))
            {
                message += "\n---> Original stack trace:\n";
            }
            else
            {
                message = string.Empty;
            }

            string exStr = exception.ToString();
            EReportMode mode = _options.ReportMode;

            if ((mode & EReportMode.EnableExceptionCallStack) != 0)
            {
                message += exStr;
            }
            else
            {
                message += exception.Message;
            }

            if ((mode & EReportMode.EnableLogging) != 0)
            {
                _logger.LogError(message);
            }

            if ((mode & EReportMode.EnableErrorDialog) != 0)
            {
                await _dialogService.ShowErrorDialogAsync(message);
            }
        }
    }
}
