using CommunityToolkit.Maui.Views;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    internal partial class PageLoading
    {
        internal class GifImageData
        {
            public byte[]? Image { get; set; }
            public int? Height { get; set; }
            public int? Width { get; set; }
        }

        public GifImageData? GifImage { get; private set; }

        /// <summary>
        /// Use loading scope to ignore inner loading function calls
        /// </summary>
        private string? _scope = null;

        private bool _wasDismissed = false;

        private LoadingPopup? _popup = null;
        private LoadingOptions? _options = null;

        public void SetLoadingOptions(LoadingOptions options)
        {
            _options = options;

            if (options.GifImageBuffer != null)
            {
                SetGifImage(options.GifImageBuffer, options.GifImageHeight, options.GifImageWidth);
            }
        }

        public void SetGifImage(byte[]? image, int? height = null, int? width = null)
        {
            GifImage ??= new GifImageData();
            GifImage.Image = image;
            GifImage.Height = height;
            GifImage.Width = width;
        }

        internal void SetGifImage(GifImageData? imageData)
        {
            GifImage = imageData;
        }

        public void Show(string message, string? scope = null, bool isCancelable = false, Action? onCancel = null)
        {
            if (_scope != null)
            {
                throw new PageLoadingException(LoadingExceptionType.ScopeAlreadyExist,
                    string.Format("Found existing scope, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = scope;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                LoadingPopup popup = CreateLoading(message, isCancelable, onCancel);
                Application.Current?.MainPage?.ShowPopup(popup);
            });
        }

        public void ShowTransparent(string? scope = null, bool isCancelable = false, Action? onCancel = null)
        {
            if (_scope != null)
            {
                throw new PageLoadingException(LoadingExceptionType.ScopeAlreadyExist,
                    string.Format("Found existing scope, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = scope;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                LoadingPopup popup = CreateLoading(null, isCancelable, onCancel);
                Application.Current?.MainPage?.ShowPopup(popup);
            });
        }

        public void Hide(string? scope = null)
        {
            if (_scope != scope)
            {
                throw new PageLoadingException(LoadingExceptionType.ScopeNotMatched,
                    string.Format("Scope is not match, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = null;

            HideLoading();
        }

        private void HideLoading()
        {
            if (!_wasDismissed)
            {
                _popup?.Close();
            }

            _popup = null;
        }

        /// <summary>
        /// Create a dialog with circular progress indicator.
        /// Transparent background will be used if message is empty, otherwise using white background.
        /// </summary>
        /// <param name="message">Optional. A message to be displayed in the loading dialog.</param>
        /// <returns>An instance of <see cref="LoadingPopup"/> representing the loading dialog.</returns>
        private LoadingPopup CreateLoading(string? message = null, bool isCancelable = false, Action? onCancel = null)
        {
            if (_popup != null)
            {
                throw new PageLoadingException(LoadingExceptionType.MultipleDialog,
                    "There's an active dialog instance, failed to create another one");
            }

            _popup = new LoadingPopup
            {
                BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : _options?.BackgroundColor,
                CornerRadius = _options?.CornerRadius,
                Message = message,
                GifImageBuffer = GifImage?.Image,
                GifImageHeight = GifImage?.Height,
                GifImageWidth = GifImage?.Width,
                CanBeDismissedByTappingOutsideOfPopup = isCancelable,
            };

            _popup.Closed += (sender, arg) =>
            {
                if (arg.WasDismissedByTappingOutsideOfPopup)
                {
                    _wasDismissed = true;
                    onCancel?.Invoke();
                }
            };

            _wasDismissed = false;

            return _popup;
        }
    }
}
