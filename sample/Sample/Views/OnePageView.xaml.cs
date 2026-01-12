using Sample.ViewModels;
using SingleScope.Mvvm.Attributes;

namespace Sample.Views;

[ViewModelOwner<OneViewModel>(IsDefaultConstructor = true)]
public partial class OnePageView : ContentPage
{
    public OnePageView()
    {
        InitializeComponent();
    }
}
