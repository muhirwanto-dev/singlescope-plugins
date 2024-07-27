using Android.Content;
using Android.Widget;
using Bumptech.Glide;
using Google.Android.Material.Dialog;
using Google.Android.Material.ProgressIndicator;
using SingleScope.Plugin.Popup.Loading;
using SingleScope.Plugin.Popup.Platforms.Android;
using AlertDialog = AndroidX.AppCompat.App.AlertDialog;

namespace SingleScope.Plugin.Popup
{
    internal partial class PageLoading
    {
        private AlertDialog? _dialog = null;

        private void ShowLoadingAndroid(string? message = null, bool isCancelable = false, Action? onCancel = null)
        {
            CreateLoading(message, isCancelable, onCancel)?.Show();
        }

        private void HideLoadingAndroid()
        {
            _dialog?.Dismiss();
            _dialog?.Dispose();
            _dialog = null;
        }

        /// <summary>
        /// Create a dialog with circular progress indicator.
        /// Transparent background will be used if message is empty, otherwise using white background.
        /// </summary>
        /// <param name="message">Optional. A message to be displayed in the loading dialog.</param>
        /// <returns>An instance of <see cref="AlertDialog"/> representing the loading dialog.</returns>
        private AlertDialog? CreateLoading(string? message = null, bool isCancelable = false, Action? onCancel = null)
        {
            if (_dialog != null)
            {
                throw new PageLoadingException(LoadingExceptionType.MultipleDialog,
                    "There's an active dialog instance, failed to create another one");
            }

            Android.App.Activity? context = Platform.CurrentActivity;
            Android.Views.View? body = context?.LayoutInflater.Inflate(Resource.Layout.popup_loading, null);

            if (context == null || body == null)
            {
                return null;
            }

            if (message != null)
            {
                var msg = body.FindViewById<TextView>(Resource.Id.progress_message);
                if (msg != null)
                {
                    msg.Text = message;
                    msg.Visibility = Android.Views.ViewStates.Visible;
                }
            }

            bool useGif = _gifImage != null;

            var image = body.FindViewById<ImageView>(Resource.Id.progress_indicator_gif);
            if (image != null)
            {
                if (useGif)
                {
                    Glide.With(context as Context)
                        .AsGif()
                        .Load(_gifImage)
                        .Into(image);
                }

                image.Visibility = useGif ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
            }
            else
            {
                useGif = false;
            }

            var indicator = body.FindViewById<CircularProgressIndicator>(Resource.Id.progress_indicator);
            if (indicator != null)
            {
                indicator.Indeterminate = true;
                indicator.Visibility = useGif ? Android.Views.ViewStates.Gone : Android.Views.ViewStates.Visible;
            }

            var builder = string.IsNullOrEmpty(message)
                ? new MaterialAlertDialogBuilder(context, Resource.Style.AppThemeOverlay_AlertDialog_Loading_Transparent)
                : new MaterialAlertDialogBuilder(context, Resource.Style.AppThemeOverlay_AlertDialog_Loading);

            _dialog = builder
                .SetCancelable(isCancelable)?
                .SetView(body)?
                .SetOnCancelListener(onCancel == null ? null : new DialogOnCancelListener(onCancel))?
                .Create();

            return _dialog;
        }
    }
}