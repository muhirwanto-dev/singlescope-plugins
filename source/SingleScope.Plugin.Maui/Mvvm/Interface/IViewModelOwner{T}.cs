namespace SingleScope.Plugin.Maui.Mvvm.Interface
{
    public interface IViewModelOwner<TViewModel>
    {
        TViewModel ViewModel { get; }
    }
}
