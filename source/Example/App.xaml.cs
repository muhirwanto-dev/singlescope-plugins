using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Reports;

namespace Example
{
    public partial class App : Application
    {
        private readonly IAnimatedLoadingDialogService _animatedLoadingDialogService;
        private readonly IDialogService _dialogService;
        private readonly IReportService<App> _reportService;

        public App(IAnimatedLoadingDialogService animatedLoadingDialogService, IDialogService dialogService, IReportService<App> reportService)
        {
            _animatedLoadingDialogService = animatedLoadingDialogService;
            _dialogService = dialogService;
            _reportService = reportService;

            InitializeComponent();

            MainPage = new AppShell();

            Task.Factory.StartNew(() => Run());
        }

        private async void Run()
        {
            const int delayMs = 5000;

            try
            {
                using (var popup = _dialogService.ShowFullPageLoading())
                {
                    await Task.Delay(delayMs);
                }

                using (var popup = _dialogService.ShowLoading("Example scoped loading"))
                {
                    await Task.Delay(delayMs);
                }

                using (var popup = _dialogService.ShowLoading("Example cancellable loading", cancelAction: () => { }))
                {
                    await Task.Delay(delayMs);
                }

                using (var popup = _animatedLoadingDialogService.ShowLoading("Example gif loading"))
                {
                    await Task.Delay(delayMs);
                }
            }
            catch (Exception ex)
            {
                await _reportService.ReportAsync(ex);
            }
        }
    }
}
