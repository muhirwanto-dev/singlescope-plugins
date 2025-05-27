using CommunityToolkit.Maui;
using SingleScope.Maui;

namespace Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSingleScopeMaui(new SingleScopeBuilderOptions
                {
                    AnimatedLoadingOptions = new()
                    {
                        GifImageUri = "file:///android_asset/loading_example.html",
                        GifImageHeight = 64,
                    },
                    ProgressiveLoadingOptions = new()
                    {
                        PopupPadding = 50,
                        IndicatorColor = Colors.Red,
                    }
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
