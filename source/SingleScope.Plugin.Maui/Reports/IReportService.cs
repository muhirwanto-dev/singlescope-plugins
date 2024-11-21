namespace SingleScope.Plugin.Maui.Reports
{
    public interface IReportService<T>
    {
        void Report(Exception exception, string? message = null);

        Task ReportAsync(Exception exception, string? message = null);
    }
}
