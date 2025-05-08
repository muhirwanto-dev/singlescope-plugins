global using INavQuery = System.Collections.Generic.IDictionary<string, object>;
global using NavQuery = System.Collections.Generic.Dictionary<string, object>;

namespace SingleScope.Maui.Navigation
{
    public interface INavigationService
    {
        protected static readonly INavQuery EmptyQuery
            = new NavQuery();

        void NavigateTo<TView>(bool animated = true)
            where TView : Page;

        void NavigateTo<TView>(INavQuery query, bool animated = true)
            where TView : Page;

        void NavigateToModal<TView>(bool animated = true)
            where TView : Page;

        void NavigateToModal<TView>(INavQuery query, bool animated = true)
            where TView : Page;

        void GoBack();

        void GoBack(INavQuery query);

        void CloseModal();

        void NavigateToRoot<TView>(string shellRoute = "///")
            where TView : Page;

        void NavigateToRoot<TView>(INavQuery query, string shellRoute = "///")
            where TView : Page;

        Task NavigateToAsync<TView>(bool animated = true)
            where TView : Page;

        /// <summary>
        /// Navigates to the specified route or page key.
        /// </summary>
        /// <param name="query">Parameters to pass to the target page/ViewModel.</param>
        Task NavigateToAsync<TView>(INavQuery query, bool animated = true)
            where TView : Page;

        Task NavigateToModalAsync<TView>(bool animated = true)
            where TView : Page;

        /// <summary>
        /// Navigates to a page modally.
        /// </summary>
        /// <param name="query">Parameters to pass to the target modal page/ViewModel.</param>
        /// <remarks>
        /// For Shell apps, if the route is registered, NavigateToAsync might be sufficient if the route is not part of the main visual hierarchy.
        /// This method provides a more explicit modal push, often wrapping the page in a NavigationPage.
        /// </remarks>
        Task NavigateToModalAsync<TView>(INavQuery query, bool animated = true)
            where TView : Page;

        /// <summary>
        /// Navigates back in the current navigation stack or modal stack.
        /// </summary>
        Task GoBackAsync();

        Task GoBackAsync(INavQuery query);

        Task<TView?> GoBackAsync<TView>()
            where TView : Page;

        Task<TView?> GoBackAsync<TView>(INavQuery query)
            where TView : Page;

        /// <summary>
        /// Closes the currently displayed modal page.
        /// </summary>
        Task CloseModalAsync();

        Task<TView?> CloseModalAsync<TView>()
            where TView : Page;

        /// <summary>
        /// Pops all pages from the current navigation stack until the root page is reached.
        /// (Shell-specific) Navigates to the root of the Shell hierarchy or a specified root route.
        /// </summary>
        /// <param name="shellRoute">The Shell route to navigate to (e.g., "//").</param>
        Task NavigateToRootAsync<TView>(string shellRoute = "///")
            where TView : Page;

        Task NavigateToRootAsync<TView>(INavQuery query, string shellRoute = "///")
            where TView : Page;
    }
}
