using System;
using Microsoft.Extensions.DependencyInjection;
using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Options;
using SingleScope.Reporting.Services;

namespace SingleScope.Reporting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static SingleScopeReportingServiceContainer AddSingleScopeReporting(
            this IServiceCollection services)
            => services.AddSingleScopeReporting(_ => { });

        public static SingleScopeReportingServiceContainer AddSingleScopeReporting(
            this IServiceCollection services, Action<ReportingOptions> configuration)
        {
            services.Configure(configuration);
            services.AddSingleton<IReportingService, ReportingService>();

            return new SingleScopeReportingServiceContainer(services);
        }
    }
}
