using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ApiInformationDemo.Common
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public virtual void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState) { }
        public virtual void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending) { }
    }
}
