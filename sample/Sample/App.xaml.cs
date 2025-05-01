using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Reports;

namespace Sample
{
    public partial class App : Application
    {
        private readonly IAnimatedLoadingDialogService _animatedLoadingDialogService;
        private readonly IDialogService _dialogService;
        private readonly IReportingService<App> _reportService;

        public App(IAnimatedLoadingDialogService animatedLoadingDialogService, IDialogService dialogService, IReportingService<App> reportService)
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
                using (var popup = _dialogService.ShowProgressiveLoading("Example progressive activity"))
                {
                    while (popup.ReturnValue.ProgressValue < 1.0)
                    {
                        await Task.Delay(delayMs / 10);

                        popup.ReturnValue.ProgressValue += 0.1;
                    }
                }

                using (var popup = _dialogService.ShowProgressiveLoading("Example progressive progress bar", ProgressiveLoadingProgressType.ProgressBar))
                {
                    while (popup.ReturnValue.ProgressValue < 1.0)
                    {
                        await Task.Delay(delayMs / 10);

                        popup.ReturnValue.ProgressValue += 0.1;
                    }
                }

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
