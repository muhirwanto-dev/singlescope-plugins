namespace SingleScope.Maui.Navigation
{
    public class NavigationService : INavigationService
    {
        public void InsertPageBefore<TView, TBefore>()
            where TView : Page
            where TBefore : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            var prev = SingleScopeServiceProvider.Current.GetService<TBefore>();
            if (prev == null)
            {
                throw new NullReferenceException($"Page {typeof(TBefore).Name} not registered");
            }

            Application.Current?.MainPage?.Navigation.InsertPageBefore(page, prev);
        }

        public void Pop<TView>() where TView : Page
        {
            _ = PopAsync<TView>();
        }

        public async Task<TView?> PopAsync<TView>() where TView : Page
        {
            var page = await (Application.Current?.MainPage?.Navigation.PopAsync() ?? Task.FromResult(default(Page)));
            if (page is not TView view)
            {
                return null;
            }

            return view;
        }

        public void PopModal<TView>() where TView : Page
        {
            _ = PopModalAsync<TView>();
        }

        public async Task<TView?> PopModalAsync<TView>() where TView : Page
        {
            var page = await (Application.Current?.MainPage?.Navigation.PopModalAsync() ?? Task.FromResult(default(Page)));
            if (page is not TView view)
            {
                return null;
            }

            return view;
        }

        public void PopToRoot(bool animated = true)
        {
            _ = PopToRootAsync(animated);
        }

        public Task PopToRootAsync(bool animated = true)
        {
            return Application.Current?.MainPage?.Navigation.PopToRootAsync(animated) ?? Task.CompletedTask;
        }

        public void Push<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page
        {
            _ = PushAsync(preNavigation, animated);
        }

        public Task PushAsync<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            preNavigation?.Invoke(page);

            return Application.Current?.MainPage?.Navigation.PushAsync(page, animated) ?? Task.CompletedTask;
        }

        public void PushModal<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page
        {
            _ = PushModalAsync(preNavigation, animated);
        }

        public Task PushModalAsync<TView>(Action<TView>? preNavigation, bool animated = true) where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            preNavigation?.Invoke(page);

            return Application.Current?.MainPage?.Navigation.PushModalAsync(page, animated) ?? Task.CompletedTask;
        }

        public void RemovePage<TView>() where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            Application.Current?.MainPage?.Navigation.RemovePage(page);
        }
    }
}
