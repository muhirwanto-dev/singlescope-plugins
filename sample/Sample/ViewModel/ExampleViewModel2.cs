using CommunityToolkit.Mvvm.ComponentModel;

namespace SingleScope.Sample.ViewModel
{
    public partial class ExampleViewModel2 : ObservableObject
    {
        [ObservableProperty]
        private bool _isTest = false;
    }
}
