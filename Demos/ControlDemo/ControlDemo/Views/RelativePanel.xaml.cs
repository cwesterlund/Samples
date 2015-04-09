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

namespace ControlDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RelativePanel : Page
    {
        public RelativePanel()
        {
            this.InitializeComponent();
            Loaded += RelativePanel_Loaded;
        }

        private void RelativePanel_Loaded(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, AboveState.Name, true);
        }

        private void StateClick(object sender, RoutedEventArgs e)
        {
            var value = (sender as Button).Tag as String;
            VisualStateManager.GoToState(this, value, true);
        }
    }
}
