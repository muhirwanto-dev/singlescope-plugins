using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SingleScope.Maui.Dialogs.Abstractions;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Mvvm.Base;
using SingleScope.Reporting.Abstractions;

namespace Sample.ViewModels
{
    public partial class OneViewModel(
        IReportingService _reportingService,
        ILoadingService _loadingService,
        IDialogService _dialogService,
        IProgressiveLoadingService _progressiveLoading
        ) : ViewModelBase
    {
        [ObservableProperty]
        private bool _testing = true;

        [RelayCommand]
        private void Appearing()
        {
            try
            {

            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }

        [RelayCommand]
        private async Task OpenScopedLoadingAsync()
        {
            try
            {
                using var _ = _loadingService.Show("scoped loading");
                await Task.Delay(3000);
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }

        [RelayCommand]
        private async Task OpenCancellableScopedLoadingAsync()
        {
            try
            {
                using var _ = _loadingService.Show("scoped loading cancelable", () => { });
                await Task.Delay(10000);
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }

        [RelayCommand]
        private async Task OpenProgressiveLoadingAsync()
        {
            try
            {
                using var loading = _progressiveLoading.Show("progressive loading");
                double progress = 0;

                do
                {
                    progress += 0.05;
                    loading.Context.UpdateProgress(progress);

                    await Task.Delay(500);
                }
                while (progress < 1.0);
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }

        [RelayCommand]
        private async Task OpenCancellableProgressiveLoadingAsync()
        {
            try
            {
                using var loading = _progressiveLoading.Show("cancellable progressive loading", () => { });
                double progress = 0;

                do
                {
                    progress += 0.05;
                    loading.Context.UpdateProgress(progress);

                    await Task.Delay(500);
                }
                while (progress < 1.0);
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }

        [RelayCommand]
        private async Task OpenAlertAsync()
        {
            try
            {
                await _dialogService.ShowAsync(DialogRequest.Alert("titel", "ahahe", cancel: "tidak"));
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }
    }
}
