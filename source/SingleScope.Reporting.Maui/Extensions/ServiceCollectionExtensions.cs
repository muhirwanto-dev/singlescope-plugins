using SingleScope.Reporting.Abstractions;
using SingleScope.Reporting.Maui.Sinks;

namespace SingleScope.Reporting.Maui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static SingleScopeReportingServiceContainer AddDialogReporting(
            this SingleScopeReportingServiceContainer container)
        {
            container.Services.AddSingleton<IReportSink, MauiDialogReportSink>();

            return container;
        }
    }
}
