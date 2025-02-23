using Microsoft.Extensions.Options;
using SingleScope.Maui.Dialogs.Controls;

namespace SingleScope.Maui.Dialogs
{
    public class AnimatedLoadingDialogService : DialogService, IAnimatedLoadingDialogService
    {
        private readonly AnimatedLoadingOptions _animatedLoadingOptions;

        public AnimatedLoadingDialogService(IOptions<AnimatedLoadingOptions> options, IOptions<ProgressiveLoadingOptions> progressiveLoadingOptions)
            : base(options, progressiveLoadingOptions)
        {
            _animatedLoadingOptions = options.Value;
        }

        protected override LoadingPopup CreateLoadingPopup(string message, Action? cancelAction)
        {
            return new LoadingPopup
            {
                Options = new AnimatedLoadingOptions
                {
                    PopupPadding = _animatedLoadingOptions.PopupPadding,
                    BackgroundColor = string.IsNullOrEmpty(message) ? Colors.Transparent : _animatedLoadingOptions.BackgroundColor,
                    CornerRadius = _animatedLoadingOptions.CornerRadius,
                    GifImageUri = _animatedLoadingOptions.GifImageUri,
                    GifImageHeight = _animatedLoadingOptions.GifImageHeight,
                    GifImageWidth = _animatedLoadingOptions.GifImageWidth,
                    Message = message,
                    MinimumHeight = _animatedLoadingOptions.MinimumHeight,
                    MinimumWidth = _animatedLoadingOptions.MinimumWidth,
                },
                CanBeDismissedByTappingOutsideOfPopup = cancelAction != null,
            };
        }
    }
}
