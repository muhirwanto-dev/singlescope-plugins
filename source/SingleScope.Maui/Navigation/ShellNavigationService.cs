
namespace SingleScope.Maui.Navigation
{
    public class ShellNavigationService : IShellNavigationService
    {
        public Shell Navigation => Shell.Current;

        public void NavigateTo<TView>(bool animated = true) where TView : Page
        {
            _ = NavigateToAsync<TView>(animated);
        }

        public void NavigateTo<TView>(INavQuery query, bool animated = true) where TView : Page
        {
            _ = NavigateToAsync<TView>(query, animated);
        }

        public void NavigateToModal<TView>(bool animated = true) where TView : Page
        {
            _ = NavigateToModalAsync<TView>(animated);
        }

        public void NavigateToModal<TView>(INavQuery query, bool animated = true) where TView : Page
        {
            _ = NavigateToModalAsync<TView>(query, animated);
        }

        public void NavigateToRoot<TView>(string shellRoute = "///")
            where TView : Page
        {
            _ = NavigateToRootAsync<TView>(shellRoute);
        }

        public void NavigateToRoot<TView>(INavQuery query, string shellRoute = "///")
            where TView : Page
        {
            _ = NavigateToRootAsync<TView>(query, shellRoute);
        }

        public void GoBack()
        {
            _ = GoBackAsync();
        }

        public void GoBack(INavQuery query)
        {
            _ = GoBackAsync(query);
        }

        public void CloseModal()
        {
            GoBack();
        }

        public Task NavigateToAsync<TView>(bool animated = true) where TView : Page
        {
            return Shell.Current.GoToAsync(typeof(TView).Name);
        }

        public Task NavigateToAsync<TView>(INavQuery query, bool animated = true) where TView : Page
        {
            return Shell.Current.GoToAsync(typeof(TView).Name, animated, query);
        }

        public Task NavigateToModalAsync<TView>(bool animated = true) where TView : Page
        {
            return NavigateToAsync<TView>(animated);
        }

        public Task NavigateToModalAsync<TView>(INavQuery query, bool animated = true) where TView : Page
        {
            return NavigateToAsync<TView>(query, animated);
        }

        public Task NavigateToRootAsync<TView>(string shellRoute = "///")
            where TView : Page
        {
            return Shell.Current.GoToAsync($"{shellRoute}{typeof(TView).Name}");
        }

        public Task NavigateToRootAsync<TView>(INavQuery query, string shellRoute = "///")
            where TView : Page
        {
            return Shell.Current.GoToAsync($"{shellRoute}{typeof(TView).Name}", query);
        }

        public Task GoBackAsync()
        {
            return this.Navigation.GoToAsync("..");
        }

        public Task GoBackAsync(INavQuery query)
        {
            return this.Navigation.GoToAsync("..", query);
        }

        public async Task<TView?> GoBackAsync<TView>() where TView : Page
        {
            if (this.Navigation.CurrentPage is not TView removed)
            {
                return null;
            }

            await GoBackAsync();

            return removed;
        }

        public async Task<TView?> GoBackAsync<TView>(INavQuery query) where TView : Page
        {
            if (this.Navigation.CurrentPage is not TView removed)
            {
                return null;
            }

            await GoBackAsync(query);

            return removed;
        }

        public Task CloseModalAsync()
        {
            return GoBackAsync();
        }

        public Task<TView?> CloseModalAsync<TView>() where TView : Page
        {
            return GoBackAsync<TView>();
        }
    }
}
