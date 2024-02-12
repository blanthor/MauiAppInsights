using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly ILogger<MainPage> _logger;
        private MyService _myService;

        public MainPage(MyService myService, ILogger<MainPage> logger)
        {
            InitializeComponent();
            _myService = myService;
            _logger = logger;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            _myService.MyAction(CounterBtn.Text);   

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
