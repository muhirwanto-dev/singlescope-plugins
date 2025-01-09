namespace SingleScope.Maui.Navigation
{
    public class ShellNavigationService : IShellNavigationService
    {
        public void Pop()
        {
            _ = PopAsync();
        }

        public Task PopAsync()
        {
            return Shell.Current.GoToAsync("..");
        }

        public void PopToRoot<TRoot>() where TRoot : Page
        {
            _ = PopToRootAsync<TRoot>();
        }

        public Task PopToRootAsync<TRoot>() where TRoot : Page
        {
            return Shell.Current.GoToAsync($"///{nameof(TRoot)}");
        }

        public void Push<TView>() where TView : Page
        {
            _ = PushAsync<TView>();
        }

        public Task PushAsync<TView>() where TView : Page
        {
            return Shell.Current.GoToAsync(nameof(TView));
        }

        public void Pop(ShellNavigationQueryParameters? query)
        {
            _ = PopAsync(query);
        }

        public Task PopAsync(ShellNavigationQueryParameters? query)
        {
            return Shell.Current.GoToAsync("..", query);
        }

        public void PopToRoot<TRoot>(ShellNavigationQueryParameters? query) where TRoot : Page
        {
            _ = PopToRootAsync<TRoot>(query);
        }

        public Task PopToRootAsync<TRoot>(ShellNavigationQueryParameters? query) where TRoot : Page
        {
            return Shell.Current.GoToAsync($"///{nameof(TRoot)}", query);
        }

        public void Push<TView>(ShellNavigationQueryParameters? query) where TView : Page
        {
            _ = PushAsync<TView>(query);
        }

        public Task PushAsync<TView>(ShellNavigationQueryParameters? query) where TView : Page
        {
            return Shell.Current.GoToAsync(nameof(TView), query);
        }
    }
}
