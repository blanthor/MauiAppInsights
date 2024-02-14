using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public partial class MainPageViewModel : ObservableObject
    {
        ILogger<MainPage> _logger;
        MyService _myService;
        public MainPageViewModel(MyService myService, ILogger<MainPage> logger)
        {
            _myService = myService;
            _logger = logger;

            _counterText = "Click me!";
        }

        [ObservableProperty]
        private string _counterText;

        [ObservableProperty]
        private int _count = 0;


        public MyService MyService { get; set;}

        [RelayCommand]
        public void CounterClicked()
        {
            // ObservableObject is weird. It doesn't update the UI if you just change the value
            // of the underlying field. CounterText is a generated property, so it will update the UI.
            CounterText = $"Clicked {++_count} times";
            _myService.MyAction(_counterText);
            _logger.LogInformation(_counterText);
        }
    }
}
