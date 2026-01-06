using Microsoft.Extensions.Logging;
using Sample.ViewModels;
using Sample.Views;
using SingleScope.Navigations.Maui.Enums;
using SingleScope.Navigations.Maui.Extensions;
using SingleScope.Reporting.Extensions;
using SingleScope.Reporting.Logging.Extensions;
using SingleScope.Reporting.Maui.Extensions;

namespace Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleScopeNavigations(opt => opt.AdapterName = NavigationAdapterName.Shell);
            builder.Services.AddSingleScopeReporting()
                .AddLogReporting()
                .AddDialogReporting();

            builder.Services.AddTransient<OnePageView>();
            builder.Services.AddTransient<OneViewModel>();
            builder.Services.AddTransient<TwoPageView>();
            builder.Services.AddTransient<TwoViewModel>();

            Routing.RegisterRoute(nameof(OnePageView), typeof(OnePageView));
            Routing.RegisterRoute(nameof(TwoPageView), typeof(TwoPageView));

            return builder.Build();
        }
    }
}
