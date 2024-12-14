using CommunityToolkit.Mvvm.ComponentModel;

namespace SingleScope.Example.ViewModel
{
    public partial class ExampleViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isTest = false;
    }
}
