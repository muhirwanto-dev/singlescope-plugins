﻿using CommunityToolkit.Maui.Views;
using SingleScope.Plugin.Popup.Loading;

namespace SingleScope.Plugin.Popup
{
    internal partial class PageLoading
    {
        public LoadingParam LoadingParam { get; } = new LoadingParam();

        /// <summary>
        /// Use loading scope to ignore inner loading function calls
        /// </summary>
        private string? _scope = null;

        private bool _wasDismissed = false;

        /// <summary>
        /// Since the popup will guarateed to Shown/Hide in the UI thread, so we might encounter an issue that the popup showing forever.
        /// This case occured when 'Hide' function called before 'Application.Current?.MainPage?.ShowPopup'.
        /// Known case:
        ///     using (...ShowScopedLoading())
        ///     {
        ///         // exception occured
        ///     }
        ///     
        /// The program will calls 'Hide' immediately, but somewhow, the popup not yet invoking 'Application.Current?.MainPage?.ShowPopup'.
        /// This case leading to infinity popup.
        /// </summary>
        private bool _isAboutToShow = false;

        private LoadingPopup? _popup = null;

        public PageLoading SetLoadingParams(LoadingParam param)
        {
            LoadingParam.BackgroundColor = param.BackgroundColor;
            LoadingParam.CornerRadius = param.CornerRadius;

            if (param.GifImageUri != null)
            {
                SetGifAssetUri(param.GifImageUri, param.GifImageHeight, param.GifImageWidth);
            }

            return this;
        }

        public PageLoading SetGifAssetUri(string? mauiAssetUri, double? height = null, double? width = null)
        {
            LoadingParam.GifImageUri = mauiAssetUri;
            LoadingParam.GifImageHeight = height;
            LoadingParam.GifImageWidth = width;

            return this;
        }

        public void Show(string message, string? scope = null, bool isCancelable = false, Action? onCancel = null)
        {
            if (_scope != null)
            {
                throw new PageLoadingException(LoadingExceptionType.ScopeAlreadyExist,
                    string.Format("Found existing scope, current scope ({0}) while requested scope ({1})", _scope, scope));
            }

            _scope = scope;
            _isAboutToShow = true;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                if (_isAboutToShow)
                {
                    LoadingPopup popup = CreateLoading(message, isCancelable, onCancel);
                    Application.Current?.MainPage?.ShowPopup(popup);
                    
                    _isAboutToShow = false;
                }
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
            _isAboutToShow = true;

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                if (_isAboutToShow)
                {
                    LoadingPopup popup = CreateLoading(null, isCancelable, onCancel);
                    Application.Current?.MainPage?.ShowPopup(popup);
                
                    _isAboutToShow = false;
                }
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

            Application.Current?.Dispatcher?.Dispatch(() =>
            {
                HideLoading();
            });
        }

        private void HideLoading()
        {
            if (!_wasDismissed)
            {
                _popup?.Close();
            }

            _popup = null;
            _isAboutToShow = false;
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
                Param = new LoadingParam
                {
                    BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : LoadingParam.BackgroundColor,
                    CornerRadius = LoadingParam.CornerRadius,
                    Message = message,
                    GifImageUri = LoadingParam.GifImageUri,
                    GifImageHeight = LoadingParam.GifImageHeight,
                    GifImageWidth = LoadingParam.GifImageWidth,
                },
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
