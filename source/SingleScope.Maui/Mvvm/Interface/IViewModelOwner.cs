namespace SingleScope.Maui.Mvvm.Interface
{
    public interface IViewModelOwner
    {
    }

    public interface IViewModelOwner<TViewModel> : IViewModelOwner
    {
        TViewModel ViewModel { get; }
    }
}
