using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ControlDemo.Services
{
    public static class Helper
    {
        public static async System.Threading.Tasks.Task<Window> Show(this Type type, object param = null)
        {
            var window = default(Window);
            var coreView = CoreApplication.CreateNewView();
            var view = default(ApplicationView);
            await coreView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                window = Window.Current;
                var frame = new Frame();
                window.Content = frame;
                frame.Navigate(type, param);
                ApplicationView.GetForCurrentView().Consolidated += Helper_Consolidated;
                view = ApplicationView.GetForCurrentView();
            });
            if (await ApplicationViewSwitcher.TryShowAsStandaloneAsync(view.Id))
            {
                await ApplicationViewSwitcher.SwitchAsync(view.Id);
                return window;
            }
            return default(Window);
        }

        public async static void SpecialClose(this Window window)
        {
            await window.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                window.Close();
            });
        }

        static void Helper_Consolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs args)
        {
            sender.Consolidated -= Helper_Consolidated;
            if (!CoreApplication.GetCurrentView().IsMain)
                Window.Current.Close();
        }
    }

    //public class WindowService
    //{
    //    public Window Window { get; private set; } = default(Window);

    //    public async void Show(Type type, object param = null)
    //    {
    //        var coreView = CoreApplication.CreateNewView();
    //        var view = default(ApplicationView);
    //        await coreView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High,
    //            () =>
    //            {
    //                this.Window = Window.Current;
    //                var frame = new Frame();
    //                this.Window.Content = frame;
    //                frame.Navigate(type, param);
    //                ApplicationView.GetForCurrentView().Consolidated += Helper_Consolidated;
    //                view = ApplicationView.GetForCurrentView();
    //            });
    //        if (await ApplicationViewSwitcher.TryShowAsStandaloneAsync(view.Id))
    //            await ApplicationViewSwitcher.SwitchAsync(view.Id);
    //    }

    //    public async void Close()
    //    {
    //        if (this.Window != null)
    //            await this.Window.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High,
    //                () =>
    //                {
    //                    this.Window.Close();
    //                    this.Window = default(Window);
    //                });
    //    }

    //    private static void Helper_Consolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs args)
    //    {
    //        sender.Consolidated -= Helper_Consolidated;
    //        if (!CoreApplication.GetCurrentView().IsMain)
    //        {
    //            Window.Current.Close();
    //        }
    //    }
    //}
}
