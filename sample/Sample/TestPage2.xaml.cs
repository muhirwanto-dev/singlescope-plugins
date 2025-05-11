using SingleScope.Maui.Mvvm.Attributes;
using SingleScope.Sample.ViewModel;

namespace SingleScope.Sample;

[ViewModelOwner<ExampleViewModel2>(IsDefaultConstructor = true)]
public partial class TestPage2 : ContentPage
{
}