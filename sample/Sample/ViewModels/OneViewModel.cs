using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SingleScope.Mvvm.Base;
using SingleScope.Reporting.Abstractions;

namespace Sample.ViewModels
{
    internal partial class OneViewModel(
        IReportingService _reportingService
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
    }
}
