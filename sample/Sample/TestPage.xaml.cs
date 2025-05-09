using SingleScope.Maui.Mvvm.Attributes;
using SingleScope.Sample.ViewModel;

namespace SingleScope.Sample;

[ViewModelOwner<ExampleViewModel>(IsDefaultConstructor = true)]
public partial class TestPage : ContentPage
{
}