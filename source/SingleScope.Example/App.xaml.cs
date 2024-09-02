using SingleScope.Plugin.Popup;

namespace SingleScope.Example
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Task.Factory.StartNew(() => Run());
        }

        private async void Run()
        {
            const int delayMs = 5000;

            using (var popup = PopupHelper.Instance.ShowTransparentScopedLoading())
            {
                await Task.Delay(delayMs);
            }

            using (var popup = PopupHelper.Instance.ShowScopedLoading("Example scoped loading"))
            {
                await Task.Delay(delayMs);
            }

            PopupHelper.Instance.ShowCancelableLoading("Example cancellable loading", onCancel: () => { }, scope: "cancellable");

            await Task.Delay(delayMs);

            PopupHelper.Instance.HideLoading("cancellable");

            PopupHelper.Instance.SetLoadingGifImageFromEmbeddedResource<App>("loading_example.gif", height: 64);

            using (var popup = PopupHelper.Instance.ShowScopedLoading("Example gif loading"))
            {
                await Task.Delay(delayMs);
            }
        }
    }
}
