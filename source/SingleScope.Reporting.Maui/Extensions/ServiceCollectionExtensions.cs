using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Maui.Sinks;
using SingleScope.Reporting.Options;

namespace SingleScope.Reporting.Maui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingleScopeReporting(
            this IServiceCollection services) 
            => services.AddSingleScopeReporting(options => { });

        public static IServiceCollection AddSingleScopeReporting(
            this IServiceCollection services, Action<ReportingOptions> options)
        {
            services.Configure(options);

            return services
                .AddSingleton<IReportSink, MauiDialogReportSink>();
        }
    }
}
