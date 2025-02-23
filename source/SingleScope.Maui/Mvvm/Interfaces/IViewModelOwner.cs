namespace SingleScope.Maui.Mvvm.Interfaces
{
    public interface IViewModelOwner
    {
    }

    public interface IViewModelOwner<TViewModel> : IViewModelOwner
    {
        TViewModel ViewModel { get; }
    }
}
