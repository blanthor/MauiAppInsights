using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public class MyService
    {
        private readonly ILogger<MyService> logger;

        public MyService(ILogger<MyService> logger)
        {
            this.logger = logger;
        }

        public void MyAction(string parameter)
        {
            logger.LogInformation("My action executed with parameter: {Parameter}", parameter);
        }

    }
}
