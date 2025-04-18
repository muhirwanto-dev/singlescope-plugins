﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
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
                .UseSingleScopePlugins(
                    animatedLoadingOptions: options =>
                    {
                        options.GifImageUri = "file:///android_asset/loading_example.html";
                        options.GifImageHeight = 64;
                    },
                    loadingOptions: options =>
                    {

                    },
                    progressiveLoadingOptions: options =>
                    {
                        options.PopupPadding = 50;
                        options.IndicatorColor = Colors.Red;
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
