using CommunityToolkit.Maui;
using Microsoft.Extensions.Options;
using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Dialogs.Options;
using SingleScope.Maui.Navigation;
using SingleScope.Maui.Navigation.Options;
using SingleScope.Maui.Reporting;
using SingleScope.Maui.Reporting.Options;

namespace SingleScope.Maui
{
    public static class DependencyInjection
    {
        public static MauiAppBuilder UseSingleScopeMaui(this MauiAppBuilder builder)
        {
            return UseSingleScopeMaui(builder, SingleScopeBuilderOptions.Default);
        }

        public static MauiAppBuilder UseSingleScopeMaui(this MauiAppBuilder builder,
            SingleScopeBuilderOptions options)
        {
            builder.Services.Configure<AnimatedLoadingOptions>(opt =>
            {
                opt.BackgroundColor = options.AnimatedLoadingOptions.BackgroundColor;
                opt.CornerRadius = options.AnimatedLoadingOptions.CornerRadius;
                opt.GifImageHeight = options.AnimatedLoadingOptions.GifImageHeight;
                opt.GifImageUri = options.AnimatedLoadingOptions.GifImageUri;
                opt.GifImageWidth = options.AnimatedLoadingOptions.GifImageWidth;
                opt.Message = options.AnimatedLoadingOptions.Message;
                opt.MinimumHeight = options.AnimatedLoadingOptions.MinimumHeight;
                opt.MinimumWidth = options.AnimatedLoadingOptions.MinimumWidth;
                opt.PopupPadding = options.AnimatedLoadingOptions.PopupPadding;
            });

            builder.Services.Configure<LoadingOptions>(opt =>
            {
                opt.BackgroundColor = options.LoadingOptions.BackgroundColor;
                opt.CornerRadius = options.LoadingOptions.CornerRadius;
                opt.Message = options.LoadingOptions.Message;
                opt.MinimumHeight = options.LoadingOptions.MinimumHeight;
                opt.MinimumWidth = options.LoadingOptions.MinimumWidth;
                opt.PopupPadding = options.LoadingOptions.PopupPadding;
            });

            builder.Services.Configure<ProgressiveLoadingOptions>(opt =>
            {
                opt.BackgroundColor = options.ProgressiveLoadingOptions.BackgroundColor;
                opt.CornerRadius = options.ProgressiveLoadingOptions.CornerRadius;
                opt.IndicatorColor = options.ProgressiveLoadingOptions.IndicatorColor;
                opt.Message = options.ProgressiveLoadingOptions.Message;
                opt.MinimumHeight = options.ProgressiveLoadingOptions.MinimumHeight;
                opt.MinimumWidth = options.ProgressiveLoadingOptions.MinimumWidth;
                opt.PopupPadding = options.ProgressiveLoadingOptions.PopupPadding;
                opt.ProgressType = options.ProgressiveLoadingOptions.ProgressType;
            });

            builder.Services.Configure<ReportingOptions>(opt =>
            {
                opt.ReportingMode = options.ReportingOptions.ReportingMode;
            });

            builder.Services.Configure<NavigationOptions>(opt =>
            {
                opt.NavigationMode = options.NavigationOptions.NavigationMode;
            });

            builder.Services.AddSingleton<INavigationService>(provider =>
            {
                var navOptions = provider.GetService<IOptions<NavigationOptions>>();
                if (navOptions?.Value is NavigationOptions opt)
                {
                    return opt.NavigationMode switch
                    {
                        Navigation.Enums.NavigationMode.PageNavigation => ActivatorUtilities.CreateInstance<PageNavigationService>(provider),
                        Navigation.Enums.NavigationMode.ShellNavigation => ActivatorUtilities.CreateInstance<ShellNavigationService>(provider),
                        _ => throw new NotSupportedException($"Navigation mode {opt.NavigationMode} is not supported.")
                    };
                }

                throw new InvalidOperationException("Navigation options are not configured.");
            });

            builder.Services.AddSingleton<IAnimatedLoadingDialogService, AnimatedLoadingDialogService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton(typeof(IReportingService<>), typeof(ReportingService<>));

            return builder;
        }
    }
}
