using ControlDemo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            // Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().IsShellChromeBackEnabled = true;
            // Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += HandleBack;
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }

        private void RelativePanelClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views.RelativePanel), null);
        }

        private void SplitViewClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views.SplitView), null);
        }

        private void Transform3dClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views._3dTransform), null);
        }

        private void DeferredClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views.XamlDefer), null);
        }

        private void PivotClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views.PivotControl), null);
        }

        private void MenuFlyoutClick(object sender, RoutedEventArgs e)
        {
            NestedFrame.Navigate(typeof(Views.MenuFlyout), null);
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
