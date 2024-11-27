namespace SingleScope.Maui.Mvvm.Interface
{
    public interface IViewModelOwner<TViewModel>
    {
        TViewModel ViewModel { get; }
    }
}
