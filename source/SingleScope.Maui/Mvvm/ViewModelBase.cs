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

        /// <summary>
        /// Indicate that user triggering a page navigation
        /// </summary>
        [ObservableProperty]
        private bool _isNavigating;

        /// <summary>
        /// Indicate that user triggering a UI interaction which should not be interrupted
        /// </summary>
        [ObservableProperty]
        private bool _isUserInteraction;

        protected bool CanNavigate() => !IsNavigating;

        protected void Navigating() => IsNavigating = true;

        protected void Navigated() => IsNavigating = false;

        protected bool CanUserInteraction() => !IsUserInteraction;

        protected void UserInteracting() => IsUserInteraction = true;

        protected void UserInteracted() => IsUserInteraction = false;
    }
}
