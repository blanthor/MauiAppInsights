using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit() // Added MauiCommunityToolkit
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();

            BuildApplicationInsights(builder);


            builder.Services.AddSingleton<ILogger>(sp =>
            {
                var factory = sp.GetRequiredService<ILoggerFactory>();
                return factory.CreateLogger("MauiAppInsights");
            });

            builder.Services.AddSingleton<MyService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void BuildApplicationInsights(MauiAppBuilder builder)
        {
            builder.Logging.AddApplicationInsights(configuration =>
            {
                configuration.TelemetryInitializers.Add(new ApplicationInitializer());
                // Replace with your Application Insights connection string 
                configuration.ConnectionString = 
                "your connection string here"; 
            }, options =>
            {
                options.IncludeScopes = true;
                options.TrackExceptionsAsExceptionTelemetry = true;
                options.FlushOnDispose = true;
            });
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IMyService, MyService>();
            return mauiAppBuilder;
        }


        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();
            return mauiAppBuilder;
        }


        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            return mauiAppBuilder;
        }
    }
}
