using CommunityToolkit.Mvvm.ComponentModel;

namespace SingleScope.Maui.Mvvm
{
    public partial class ViewModelBase : ObservableObject
    {
        /// <summary>
        /// Indicate that user triggering Swipe-to-Refresh action
        /// </summary>
        [ObservableProperty]
        private bool _isRefreshing;
    }
}
