using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ApiInformationDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondPage : Page
    {
        Services.NavigationService navigationService;

        public SecondPage()
        {
            this.InitializeComponent();
            navigationService = ((ApiInformationDemo.App)App.Current).NavigationService;


            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
            else
            {
                backButton.Click += BackButton_Click;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            GoBack();          
        }

        private void GoBack()
        {
            if (navigationService.CanGoBack())
            {
                navigationService.GoBack();
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            GoBack();        
        }

        public bool BackButtonVisible
        {
            get
            {
               return (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"));
            }
        }

    }
}
