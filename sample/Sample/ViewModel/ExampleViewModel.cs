using CommunityToolkit.Mvvm.ComponentModel;

namespace SingleScope.Sample.ViewModel
{
    public partial class ExampleViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isTest = false;
    }
}
