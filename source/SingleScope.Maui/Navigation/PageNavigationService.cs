namespace SingleScope.Maui.Navigation
{
    public class PageNavigationService : IPageNavigationService
    {
        public INavigation Navigation => Application.Current?.MainPage?.Navigation ?? default!;

        public void NavigateTo<TView>(bool animated = true)
            where TView : Page
        {
            _ = NavigateToAsync<TView>(animated);
        }

        public void NavigateTo<TView>(INavQuery query, bool animated = true)
            where TView : Page
        {
            _ = NavigateToAsync<TView>(query, animated);
        }

        public void NavigateToModal<TView>(bool animated = true)
            where TView : Page
        {
            _ = NavigateToModalAsync<TView>(animated);
        }

        public void NavigateToModal<TView>(INavQuery query, bool animated = true)
            where TView : Page
        {
            _ = NavigateToModalAsync<TView>(query, animated);
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
            _ = CloseModalAsync();
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

        public Task NavigateToAsync<TView>(bool animated = true)
            where TView : Page
        {
            return NavigateToAsync<TView>(INavigationService.EmptyQuery, animated);
        }

        public Task NavigateToAsync<TView>(INavQuery query, bool animated = true)
            where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            ReadQuery(page, query);

            return this.Navigation.PushAsync(page, animated) ?? Task.CompletedTask;
        }

        public Task NavigateToModalAsync<TView>(bool animated = true)
            where TView : Page
        {
            return NavigateToModalAsync<TView>(INavigationService.EmptyQuery, animated);
        }

        public Task NavigateToModalAsync<TView>(INavQuery query, bool animated = true)
            where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            ReadQuery(page, query);

            return this.Navigation.PushModalAsync(page, animated) ?? Task.CompletedTask;
        }

        public async Task GoBackAsync()
        {
            await this.Navigation.PopAsync();
        }

        public async Task GoBackAsync(INavQuery query)
        {
            await GoBackAsync<Page>(query);
        }

        public async Task<TView?> GoBackAsync<TView>()
            where TView : Page
        {
            var page = await (this.Navigation.PopAsync() ?? Task.FromResult(default(Page)));
            if (page is not TView view)
            {
                return null;
            }

            return view;
        }

        public async Task<TView?> GoBackAsync<TView>(INavQuery query)
            where TView : Page
        {
            var removed = await GoBackAsync<TView>();

            if (this.Navigation.NavigationStack.LastOrDefault() is TView top
                && top != removed)
            {
                ReadQuery(top, query);
            }

            return removed;
        }

        public async Task CloseModalAsync()
        {
            await this.Navigation.PopModalAsync();
        }

        public async Task<TView?> CloseModalAsync<TView>()
            where TView : Page
        {
            var page = await (this.Navigation.PopModalAsync() ?? Task.FromResult(default(Page)));
            if (page is not TView view)
            {
                return null;
            }

            return view;
        }

        public async Task NavigateToRootAsync<TView>(string shellRoute = "///")
            where TView : Page
        {
            await (this.Navigation.PopToRootAsync() ?? Task.CompletedTask);
        }

        public async Task NavigateToRootAsync<TView>(INavQuery query, string shellRoute = "///")
            where TView : Page
        {
            await NavigateToRootAsync<TView>(shellRoute);

            if (this.Navigation.NavigationStack.LastOrDefault() is Page top)
            {
                ReadQuery(top, query);
            }
        }

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

            this.Navigation.InsertPageBefore(page, prev);
        }

        public void RemovePage<TView>() where TView : Page
        {
            var page = SingleScopeServiceProvider.Current.GetService<TView>();
            if (page == null)
            {
                throw new NullReferenceException($"Page {typeof(TView).Name} not registered");
            }

            this.Navigation.RemovePage(page);
        }

        private void ReadQuery(Page page, INavQuery query)
        {
            foreach (var item in query)
            {
                page.BindingContext?.GetType().GetProperty(item.Key)?.SetValue(page.BindingContext, item.Value);
            }
        }
    }
}
