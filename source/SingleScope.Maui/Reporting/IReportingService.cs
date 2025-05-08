namespace SingleScope.Maui.Reporting
{
    public interface IReportingService<T>
    {
        void Report(Exception exception, string? message = null);

        Task ReportAsync(Exception exception, string? message = null);
    }
}
