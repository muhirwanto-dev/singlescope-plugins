using CommunityToolkit.Maui;
using SingleScope.Maui.Dialogs.Abstractions;
using SingleScope.Maui.Dialogs.Core;
using SingleScope.Maui.Dialogs.Options;
using SingleScope.Maui.Loadings.Abstractions;
using SingleScope.Maui.Loadings.Core;
using SingleScope.Maui.Loadings.Options;
using SingleScope.Maui.Shared.Options;

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
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.Configure<DialogOptions>(opt =>
            {
                opt.PageOptions.PageSourceType = options.DialogOptions.PageOptions.PageSourceType;
            });

            builder.Services.Configure<LoadingOptions>(opt =>
            {
                opt.PageOptions.PageSourceType = options.LoadingOptions.PageOptions.PageSourceType;
                opt.Animation = options.LoadingOptions.Animation;
                opt.CornerRadius = options.LoadingOptions.CornerRadius;
                opt.MinimumHeight = options.LoadingOptions.MinimumHeight;
                opt.MinimumWidth = options.LoadingOptions.MinimumWidth;
                opt.Padding = options.LoadingOptions.Padding;
                opt.PanelColor = options.LoadingOptions.PanelColor;
            });

            builder.Services.Configure<ProgressiveLoadingOptions>(opt =>
            {
                opt.PageOptions.PageSourceType = options.ProgressiveLoadingOptions.PageOptions.PageSourceType;
                opt.Type = options.ProgressiveLoadingOptions.Type;
                opt.InitialProgress = options.ProgressiveLoadingOptions.InitialProgress;
                opt.IndicatorColor = options.ProgressiveLoadingOptions.IndicatorColor;
                opt.CornerRadius = options.ProgressiveLoadingOptions.CornerRadius;
                opt.MinimumHeight = options.ProgressiveLoadingOptions.MinimumHeight;
                opt.MinimumWidth = options.ProgressiveLoadingOptions.MinimumWidth;
                opt.Padding = options.ProgressiveLoadingOptions.Padding;
                opt.PanelColor = options.ProgressiveLoadingOptions.PanelColor;
            });

            // Register Renderers
            builder.Services.AddTransient<ILoadingRenderer, LoadingRenderer>();
            builder.Services.AddSingleton<ILoadingService, LoadingService>();
            builder.Services.AddTransient<IProgressiveLoadingRenderer, ProgressiveLoadingRenderer>();
            builder.Services.AddSingleton<IProgressiveLoadingService, ProgressiveLoadingService>();
            builder.Services.AddSingleton<LoadingFactory>();

            builder.Services.AddTransient<Func<ILoadingRenderer>>(sp => () => sp.GetRequiredService<ILoadingRenderer>());
            builder.Services.AddTransient<Func<IProgressiveLoadingRenderer>>(sp => () => sp.GetRequiredService<IProgressiveLoadingRenderer>());

            return builder;
        }
    }
}
