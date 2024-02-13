using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public class MyService : IMyService
    {
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger)
        {
            this._logger = logger;
        }

        public void MyAction(string parameter)
        {
            _logger.LogInformation("My action executed with parameter: {Parameter}", parameter);

            try
            {
                // Do something
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
            }

        }

    }
}
