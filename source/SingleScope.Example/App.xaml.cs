using SingleScope.Plugin.Popup;

namespace SingleScope.Example
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Task.Factory.StartNew(() => Hit());
        }

        private async void Hit()
        {
            //using (var popup = PopupHelper.Instance.ShowScopedLoading("example scoped"))
            //{
            //    await Task.Delay(5000);
            //}

            PopupHelper.Instance.SetGifLoadingEmbeddedResource<App>("loading_example.gif", height: 196);

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
