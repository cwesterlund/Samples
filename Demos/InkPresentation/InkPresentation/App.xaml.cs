using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace InkPresentation
{
    sealed partial class App : Common.ApplicationBase
    {
        public App() : base()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchedAsync(LaunchActivatedEventArgs e)
        {
            // first launch navigation
            this.NavigationService.Navigate(typeof(Views.MainPage));
            return base.OnLaunchedAsync(e);
        }
    }
}
