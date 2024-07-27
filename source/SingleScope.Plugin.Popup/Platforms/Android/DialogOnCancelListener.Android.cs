using Android.Content;

namespace SingleScope.Plugin.Popup.Platforms.Android
{
    public partial class DialogOnCancelListener : Java.Lang.Object, IDialogInterfaceOnCancelListener
    {
        private readonly Action _onCancelCallback;

        public DialogOnCancelListener(Action onCancelCallback)
        {
            _onCancelCallback = onCancelCallback;
        }

        public void OnCancel(IDialogInterface? dialog)
        {
            _onCancelCallback.Invoke();
        }
    }
}
