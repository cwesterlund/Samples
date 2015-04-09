using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace ApiInformationDemo
{
    sealed partial class App : Common.ApplicationBase
    {
        public App() : base()
        {
            this.InitializeComponent();
        }



        protected override Task OnLaunchedByPrimaryTileAsync(LaunchActivatedEventArgs e)
        {
            this.NavigationService.Navigate(typeof(Views.MainPage));
            return base.OnLaunchedByPrimaryTileAsync(e);
        }
    }
}
