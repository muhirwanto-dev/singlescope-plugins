using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Maui.Sinks;

namespace SingleScope.Reporting.Maui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSingleScopeReportingMaui(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IReportSink, MauiDialogReportSink>();
        }
    }
}
