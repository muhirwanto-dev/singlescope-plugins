using CommunityToolkit.Maui;
using SingleScope.Maui.Dialogs;
using SingleScope.Maui.Reports;

namespace SingleScope.Maui
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseSingleScopePlugins(this MauiAppBuilder builder,
            Action<AnimatedLoadingOptions>? animatedLoadingOptions = null,
            Action<LoadingOptions>? loadingOptions = null,
            Action<ProgressiveLoadingOptions>? progressiveLoadingOptions = null,
            Action<ReportOptions>? reportOptions = null)
        {
            if (animatedLoadingOptions != null)
            {
                builder.Services.Configure(animatedLoadingOptions);
            }
            else
            {
                builder.Services.Configure<AnimatedLoadingOptions>(options => { });
            }

            if (loadingOptions != null)
            {
                builder.Services.Configure(loadingOptions);
            }
            else
            {
                builder.Services.Configure<LoadingOptions>(options => { });
            }

            if (progressiveLoadingOptions != null)
            {
                builder.Services.Configure(progressiveLoadingOptions);
            }
            else
            {
                builder.Services.Configure<ProgressiveLoadingOptions>(options => { });
            }

            if (reportOptions != null)
            {
                builder.Services.Configure(reportOptions);
            }
            else
            {
                builder.Services.Configure<ReportOptions>(options => { });
            }

            builder.Services.AddSingleton<IAnimatedLoadingDialogService, AnimatedLoadingDialogService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();
            builder.Services.AddSingleton(typeof(IReportService<>), typeof(ReportService<>));

            return builder;
        }
    }
}
