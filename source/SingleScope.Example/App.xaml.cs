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
            //using (var popup = PopupHelper.Instance.ShowScopedLoading("example scoped"))
            //{
            //    await Task.Delay(5000);
            //}

            PopupHelper.Instance.SetLoadingGifImageFromEmbeddedResource<App>("loading_example.gif", height: 196);

            using (var popup = PopupHelper.Instance.ShowScopedLoading("example gif loading"))
            {
                await Task.Delay(30000);
            }

            using (var popup = PopupHelper.Instance.ShowTransparentScopedLoading())
            {
                await Task.Delay(30000);
            }
        }
    }
}
