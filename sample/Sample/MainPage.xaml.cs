using Sample.Views;
using SingleScope.Navigations.Abstractions;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        private readonly INavigationService _navigationService;

        int count = 0;

        public MainPage(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            _navigationService.NavigateToAsync<OnePageView>();
        }
    }
}
