using Microsoft.Extensions.Logging;

namespace MauiAppInsights
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
         
            InitializeComponent();

            this.BindingContext = mainPageViewModel;
        }
    }

}
