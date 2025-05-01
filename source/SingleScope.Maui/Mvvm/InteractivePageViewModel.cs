using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SingleScope.Common;

namespace SingleScope.Maui.Mvvm
{
    public partial class InteractivePageViewModel : RecipientBaseViewModel
    {
        private readonly Dictionary<string, ICollection<IRelayCommand>> _interactionCommands = new();

        /// <summary>
        /// Indicate that user triggering Swipe-to-Refresh action
        /// </summary>
        [ObservableProperty]
        private bool _isRefreshing;

        /// <summary>
        /// Indicate that user triggering a page navigation
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private bool _isNavigating;

        /// <summary>
        /// Indicate that user triggering a UI interaction which should not be interrupted
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private bool _isUserInteraction;

        protected bool CanRefresh() => !IsRefreshing;

        protected bool CanNavigate() => !IsNavigating;

        protected bool CanUserInteraction() => !IsUserInteraction;

        protected void Refreshing() => IsRefreshing = true;

        protected void Refreshed() => IsRefreshing = false;

        protected void Navigating() => IsNavigating = true;

        protected void Navigated() => IsNavigating = false;

        protected void UserInteracting() => IsUserInteraction = true;

        protected void UserInteracted() => IsUserInteraction = false;

        public IValueDisposable StartRefresh()
        {
            Refreshing();

            return ValueDisposable.Create(Refreshed);
        }

        public IValueDisposable StartNavigation()
        {
            Navigating();

            return ValueDisposable.Create(Navigated);
        }

        public IValueDisposable StartUserInteraction()
        {
            UserInteracting();

            return ValueDisposable.Create(UserInteracted);
        }

        protected override void Broadcast<T>(T oldValue, T newValue, string? propertyName)
        {
            base.Broadcast(oldValue, newValue, propertyName);

            if (propertyName != null)
            {
                if (_interactionCommands.TryGetValue(propertyName, out var commands))
                {
                    foreach (var command in commands)
                    {
                        command.NotifyCanExecuteChanged();
                    }
                }
            }
        }

        protected void RegisterInteractionCommand(string property, IRelayCommand command)
        {
            if (_interactionCommands.TryGetValue(property, out var commands))
            {
                commands.Add(command);
            }
            else
            {
                _interactionCommands.Add(property, new List<IRelayCommand> { command });
            }
        }

        protected void UnRegisterInteractionCommand(string property, IRelayCommand command)
        {
            if (_interactionCommands.TryGetValue(property, out var commands))
            {
                commands.Remove(command);
            }
        }
    }
}
