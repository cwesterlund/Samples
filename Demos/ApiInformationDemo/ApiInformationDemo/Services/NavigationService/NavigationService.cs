using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ApiInformationDemo.Services
{
    public class NavigationService
    {
        NavigationFacade _frame;
        string LastNavigationParameter { get; set; /* TODO: persist */ }
        string LastNavigationType { get; set; /* TODO: persist */ }

        public NavigationService(Frame frame)
        {
            _frame = new NavigationFacade(frame);
            _frame.Navigating += (s, e) => NavigateFrom(false);
            _frame.Navigated += (s, e) => NavigateTo(e.NavigationMode, e.Parameter);
        }

        void NavigateFrom(bool suspending)
        {
            var page = _frame.Content as FrameworkElement;
            if (page != null)
            {
                var viewmodel = page.DataContext as Common.ModelBase;
                if (viewmodel != null)
                {
                    // TODO: get existing state
                    viewmodel.OnNavigatedFrom(null, suspending);
                }
            }
        }

        void NavigateTo(NavigationMode mode, string parameter)
        {
            LastNavigationParameter = parameter;
            LastNavigationType = _frame.Content.GetType().FullName;

            if (mode == NavigationMode.New)
            {
                // TODO: clear existing state
            }

            var page = _frame.Content as FrameworkElement;
            if (page != null)
            {
                var viewmodel = page.DataContext as Common.ViewModelBase;
                if (viewmodel != null)
                {
                    // TODO: fetch state
                    viewmodel.OnNavigatedTo(parameter, mode, null);
                }
            }
        }

        public bool Navigate(Type page, string parameter = null)
        {
            if (page == null)
                throw new ArgumentNullException("page");
            if (page.FullName.Equals(LastNavigationType) && parameter == LastNavigationParameter)
                return false;
            return _frame.Navigate(page, parameter);
        }

        public void RestoreSavedNavigation() { /* TODO */ }

        public void GoBack() { _frame.GoBack(); }
        public bool CanGoBack() { return _frame.CanGoBack; }
        public void ClearHistory() { _frame.SetNavigationState("1,0"); }
        public void Suspending() { NavigateFrom(true); }

        public void Show(SettingsFlyout flyout, object parameter = null)
        {
            if (flyout == null)
                throw new ArgumentNullException("flyout");
            var viewmodel = flyout.DataContext as Common.ViewModelBase;
            if (viewmodel != null)
                viewmodel.OnNavigatedTo(parameter, NavigationMode.New, null);
            flyout.Show();
        }
    }
}

