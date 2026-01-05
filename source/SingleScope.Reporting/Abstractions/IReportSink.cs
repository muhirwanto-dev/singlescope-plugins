using System.Threading;
using System.Threading.Tasks;
using SingleScope.Reporting.Enums;
using SingleScope.Reporting.Models;

namespace SingleScope.Reporting.Abstractions
{
    public interface IReportSink
    {
        bool CanHandle(ReportingMode mode, Report report);

        Task HandleAsync(ReportingMode mode, Report report, CancellationToken cancellationToken = default);
    }
}
