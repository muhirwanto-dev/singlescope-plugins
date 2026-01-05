using Microsoft.Extensions.DependencyInjection;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Services;

namespace SingleScope.Reporting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingleScopeReporting(
            this IServiceCollection services) => services
                .AddSingleton<IReportingService, ReportingService>();
    }
}
