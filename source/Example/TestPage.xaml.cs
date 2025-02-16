using SingleScope.Example.ViewModel;
using SingleScope.Maui.Mvvm.Attributes;

namespace SingleScope.Example;

[ViewModelOwner(typeof(ExampleViewModel), IsDefaultConstructor = true)]
public partial class TestPage : ContentPage
{
}