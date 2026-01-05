using Microsoft.Extensions.DependencyInjection;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Logging.Sinks;

namespace SingleScope.Reporting.Logging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingleScopeReportingLogging(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IReportSink, LoggerReportSink>();
        }
    }
}
