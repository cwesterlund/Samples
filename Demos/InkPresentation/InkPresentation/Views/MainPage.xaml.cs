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

namespace InkPresentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Windows.UI.Input.Inking.InkStrokeContainer _strokeContainer = new Windows.UI.Input.Inking.InkStrokeContainer();

        public MainPage()
        {
            this.InitializeComponent();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            inkCanvas.DirectInk.InputTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse |
                Windows.UI.Core.CoreInputDeviceTypes.Pen |
                Windows.UI.Core.CoreInputDeviceTypes.Touch;

            var dda = inkCanvas.DirectInk.GetDefaultDrawingAttributes();
            dda.Color = Windows.UI.ColorHelper.FromArgb(255, 255, 0, 0);
            dda.Size = new Size(20, 100);
            dda.PenTip = Windows.UI.Input.Inking.PenTipShape.Rectangle;
            inkCanvas.DirectInk.SetDefaultDrawingAttributes(dda);

            inkCanvas.DirectInk.StrokesCollected += DirectInk_StrokesCollected;
            base.OnNavigatedTo(e);
        }
        private void DirectInk_StrokesCollected(Windows.UI.Input.Inking.DirectInk sender, Windows.UI.Input.Inking.InkEventArgs args)
        {
            foreach (var stroke in args.Strokes)
            {
                _strokeContainer.AddStroke(stroke);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DirectInk.ClearAllStrokes();
            _strokeContainer = new Windows.UI.Input.Inking.InkStrokeContainer();//
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var fsp = new Windows.Storage.Pickers.FileSavePicker();
            fsp.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            fsp.FileTypeChoices.Add("GIF with embedded ISF", new List<string> { ".gif" });

            var file = await fsp.PickSaveFileAsync();
            if (null != file)
            {
                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
                {
                    await _strokeContainer.SaveAsync(stream);
                }
            }


        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            var fop = new Windows.Storage.Pickers.FileOpenPicker();
            fop.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            fop.FileTypeFilter.Add(".gif");
            var file = await fop.PickSingleFileAsync();

            if (null != file)
            {
                using (var stream = await file.OpenSequentialReadAsync())
                {
                    await _strokeContainer.LoadAsync(stream);
                    inkCanvas.DirectInk.DrawStrokes(_strokeContainer.GetStrokes());
                }
            }
        }
    }
}
