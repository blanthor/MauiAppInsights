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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            BuildApplicationInsights(builder);

            //builder.Services.AddLogging(loggingBuilder =>
            //{
            //    loggingBuilder.AddApplicationInsights();
            //});

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
                // Replace with your Application Insights connection string (instrumentation key)
                configuration.ConnectionString = 
                "InstrumentationKey=78256835-5652-4d21-a15e-e898cdf30a82;IngestionEndpoint=https://southcentralus-3.in.applicationinsights.azure.com/;LiveEndpoint=https://southcentralus.livediagnostics.monitor.azure.com/"; 
            }, options =>
            {
                options.IncludeScopes = true;
            });

        }
    }
}
