using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using SingleScope.Maui.Loadings.Abstractions;

namespace SingleScope.Maui.Loadings.Core
{
    internal abstract class LoadingRendererBase : ILoadingRenderer
    {
        protected bool _isCancellable = false;
        protected Action<bool> _onClosed = _ => { };

        public bool IsCancelled { get; protected set; }

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

        protected static Task HideInternalAsync(Popup? popup) => popup?.CloseAsync() ?? Task.CompletedTask;

        protected Task ShowInternalAsync(Page? page, Popup popup)
        {
            popup.Closed += (_, _) =>
            {
                IsCancelled = false;
                _onClosed.Invoke(IsCancelled);
            };

            return (page?.ShowPopupAsync(popup, new PopupOptions
            {
                CanBeDismissedByTappingOutsideOfPopup = _isCancellable,
                OnTappingOutsideOfPopup = () =>
                {
                    IsCancelled = true;
                    _onClosed.Invoke(IsCancelled);
                },
            }) ?? Task.CompletedTask);
        }
    }
}
