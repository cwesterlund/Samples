﻿using System;
using InkPresentation.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media;

namespace InkPresentation.ViewModels
{
    public class DetailPageViewModel : Common.ViewModelBase
    {
        public DetailPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                LoadDesignData();
        }

        public override void OnNavigatedTo(string parameter, NavigationMode mode, Dictionary<string, object> state)
        {
            LoadRuntimeData(parameter);
        }

        private void LoadDesignData()
        {
            this.ColorInfo = new Models.ColorInfo
            {
                Name = "Orange",
                Color = Colors.Orange,
            };
        }

        private async void LoadRuntimeData(string parameter)
        {
            var repository = new Repositories.ColorRepository();
            this.ColorInfo = await repository.GetColorAsync(parameter);
        }

        private Models.ColorInfo _colorInfo;
        public Models.ColorInfo ColorInfo
        {
            get { return _colorInfo; }
            set
            {
                Set(ref _colorInfo, value);
                if (value != null)
                {
                    var triad = this.ColorInfo.Color.GetTriads().ToArray();
                    this.Variant1 = new SolidColorBrush(triad[0]);
                    this.Variant2 = new SolidColorBrush(triad[1]);
                    this.Variant3 = new SolidColorBrush(triad[2]);
                }
            }
        }

        private SolidColorBrush _variant1;
        public SolidColorBrush Variant1 { get { return _variant1; } set { Set(ref _variant1, value); } }

        private SolidColorBrush _variant2;
        public SolidColorBrush Variant2 { get { return _variant2; } set { Set(ref _variant2, value); } }

        private SolidColorBrush _variant3;
        public SolidColorBrush Variant3 { get { return _variant3; } set { Set(ref _variant3, value); } }

        public Common.Command GoBackCommand
        {
            get { return new Common.Command(() => { (App.Current as Common.ApplicationBase).NavigationService.GoBack(); }); }
        }
    }
}
