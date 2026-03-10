using Sample.ViewModels;
using SingleScope.Mvvm.Attributes;

namespace Sample.Views;

[ViewModelOwner<TwoViewModel>(IsDefaultConstructor = false)]
public partial class TwoPageView : ContentPage
{
    public TwoPageView()
    {
        InitializeComponent();
    }
}