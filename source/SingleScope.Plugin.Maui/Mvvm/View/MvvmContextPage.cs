using SingleScope.Plugin.Maui.Mvvm.Interface;

namespace SingleScope.Plugin.Maui.Mvvm.View
{
    public class MvvmContextPage<TViewModel> : ContentPage, IViewModelOwner<TViewModel>
        where TViewModel : class
    {
        public TViewModel ViewModel { get; }

        protected MvvmContextPage()
        {
            ViewModel = SingleScopeServiceProvider.Current.GetRequiredService<TViewModel>();
            BindingContext = ViewModel;
        }
    }
}
