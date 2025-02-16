using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SingleScope.Maui.Mvvm
{
    public partial class InteractiveViewModelBase : RecipientViewModelBase
    {
        private readonly Dictionary<string, ICollection<IRelayCommand>> _interactionCommands = new();

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

        protected bool CanNavigate() => !IsNavigating;

        protected void Navigating() => IsNavigating = true;

        protected void Navigated() => IsNavigating = false;

        protected bool CanUserInteraction() => !IsUserInteraction;

        protected void UserInteracting() => IsUserInteraction = true;

        protected void UserInteracted() => IsUserInteraction = false;

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
