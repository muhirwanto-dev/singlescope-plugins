using Microsoft.Extensions.Options;
using SingleScope.Maui.Controls;

namespace SingleScope.Maui.Dialogs
{
    public class AnimatedLoadingDialogService : DialogService, IAnimatedLoadingDialogService
    {
        private readonly AnimatedLoadingOptions _animatedLoadingOptions;

        public AnimatedLoadingDialogService(IOptions<AnimatedLoadingOptions> options)
            : base(options)
        {
            _animatedLoadingOptions = options.Value;
        }

        protected override LoadingPopup CreateLoadingPopup(string message, Action? cancelAction)
        {
            return new LoadingPopup
            {
                Param = new AnimatedLoadingOptions
                {
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
