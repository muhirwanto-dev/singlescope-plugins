using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using SingleScope.Maui.Loadings.Abstractions;

namespace SingleScope.Maui.Loadings.Core
{
    internal abstract class LoadingRendererBase : ILoadingRenderer
    {
        protected bool _isCancellable = false;
        protected Action<bool> _onClosed = _ => { };

        public bool IsCancelled { get; protected set; } = false;

        public ILoadingRenderer Cancellable(bool enable)
        {
            _isCancellable = enable;

            return this;
        }

        public ILoadingRenderer WhenClosed(Action<bool> onClosed)
        {
            _onClosed = onClosed;

            return this;
        }

        public abstract Task HideAsync();

        public abstract Task ShowAsync(string? message = null);

        protected static async Task HideInternalAsync(Popup? popup)
        {
            try
            {
                await (popup?.CloseAsync() ?? Task.CompletedTask);
            }
            catch
            {
                // Intentionally ignore exceptions that occur when closing a popup
                // which has already been removed or cannot be found (e.g. PopupNotFoundException).
                // Swallowing prevents these non-critical race-condition errors from bubbling.
            }
        }

        protected Task ShowInternalAsync(Page? page, Popup popup)
        {
            popup.Closed += (_, _) =>
            {
                _onClosed.Invoke(IsCancelled);
            };

            var options = new PopupOptions
            {
                CanBeDismissedByTappingOutsideOfPopup = _isCancellable,
                OnTappingOutsideOfPopup = () =>
                {
                    IsCancelled = true;
                },
                Shadow = null,
                Shape = new RoundRectangle
                {
                    StrokeThickness = 0,
                },
            };

            if (page is Shell shell)
            {
                return (shell?.ShowPopupAsync(popup, options) ?? Task.CompletedTask);
            }

            return (page?.ShowPopupAsync(popup, options) ?? Task.CompletedTask);
        }
    }
}
