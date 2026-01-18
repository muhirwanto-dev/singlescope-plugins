using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Dialogs.Abstractions;
using SingleScope.Maui.Dialogs.Models;
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
                await using var _ = _loadingService.ShowAsync("scoped loading");
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
                await using var _ = _loadingService.ShowAsync("scoped loading cancelable", cancelAction: () => { });
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
                await using var loading = _progressiveLoading.ShowAsync("progressive loading");
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
                await using var loading = _progressiveLoading.ShowAsync("cancellable progressive loading", () => { });
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
                await _dialogService.ShowAsync(Dialog.Alert("Dialog title", "The message: lorem ipsum dolor sir amet", cancel: "Close"));
            }
            catch (Exception ex)
            {
                _reportingService.Report(ex);
            }
        }
    }
}
