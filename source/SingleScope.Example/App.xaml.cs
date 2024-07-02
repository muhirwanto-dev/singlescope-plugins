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
            using (var popup = PopupHelper.Instance.ShowScopedLoading("example scoped"))
            {
                await Task.Delay(5000);
            }
        }
    }
}
