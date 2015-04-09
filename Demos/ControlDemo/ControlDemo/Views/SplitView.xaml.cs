using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ControlDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitView : Page
    {
        public SplitView()
        {
            this.InitializeComponent();
        }

        private void PlacementLeft_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.PanePlacement = SplitViewPanePlacement.Left;
        }

        private void PlacementRight_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.PanePlacement = SplitViewPanePlacement.Right;
        }

        private void BackgroundGainsboro_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.PaneBackground = new SolidColorBrush(Colors.Gainsboro);
        }

        private void BackgroundSteelBlue_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.PaneBackground = new SolidColorBrush(Colors.LightSteelBlue);
        }

        private void DisplayModeInline_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.DisplayMode = SplitViewDisplayMode.Inline;
        }

        private void DisplayModeOverlay_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.DisplayMode = SplitViewDisplayMode.Overlay;
        }

        private void DisplayModeCompactInline_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.DisplayMode = SplitViewDisplayMode.CompactInline;
        }

        private void DisplayModeCompactOverlay_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            this.splitView.IsPaneOpen = true;
        }
    }
}
