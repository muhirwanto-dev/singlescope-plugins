using Microsoft.Extensions.DependencyInjection;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Logging.Sinks;

namespace SingleScope.Reporting.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static SingleScopeReportingServiceContainer AddLogReporting(
            this SingleScopeReportingServiceContainer container)
        {
            container.Services.AddSingleton<IReportSink, LoggerReportSink>();

            return container;
        }
    }
}
