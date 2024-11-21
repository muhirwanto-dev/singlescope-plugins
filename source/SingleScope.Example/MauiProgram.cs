using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SingleScope.Plugin.Maui;

namespace SingleScope.Example
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSingleScopePlugins(
                    animatedLoadingOptions: options =>
                    {
                        options.GifImageUri = "file:///android_asset/loading_example.html";
                        options.GifImageHeight = 64;
                    },
                    loadingOptions: options =>
                    {

                    },
                    reportOptions: options =>
                    {

                    })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
