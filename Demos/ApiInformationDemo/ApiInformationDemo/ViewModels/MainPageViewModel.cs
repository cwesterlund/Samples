using System.Collections.ObjectModel;
using System.Linq;

namespace ApiInformationDemo.ViewModels
{
    class MainPageViewModel : Common.ViewModelBase
    {
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                LoadDesignData();
            else
                LoadRuntimeData();
        }

        private void LoadDesignData()
        {
            var repository = new Repositories.ColorRepository();
            this.Colors.Clear();
            foreach (var color in repository.GetColors())
                this.Colors.Add(color);
            this.Selected = (this.Colors.Any()) ? Colors.First() : default(Models.ColorInfo);
        }

        private void LoadRuntimeData()
        {
            var repository = new Repositories.ColorRepository();
            this.Colors.Clear();
            foreach (var color in repository.GetColors())
                this.Colors.Add(color);
            this.Selected = (this.Colors.Any()) ? Colors.First() : default(Models.ColorInfo);
        }

        private Models.ColorInfo _selected;
        public Models.ColorInfo Selected { get { return _selected; } set { Set(ref _selected, value); } }

        private ObservableCollection<Models.ColorInfo> _colors;
        public ObservableCollection<Models.ColorInfo> Colors { get { return _colors ?? (_colors = new ObservableCollection<Models.ColorInfo>()); } }

        private Common.Command _refreshCommand;
        public Common.Command RefreshCommand { get { return _refreshCommand ?? (_refreshCommand = new Common.Command(() => { LoadRuntimeData(); })); } }
    }
}
