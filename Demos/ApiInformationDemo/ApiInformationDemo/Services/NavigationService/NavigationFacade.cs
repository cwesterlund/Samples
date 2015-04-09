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
    public class NavigationFacade
    {
        readonly Frame _frame;
        readonly List<EventHandler<NavigationEventArgs>> _navigatedEventHandlers;
        readonly List<EventHandler> _navigatingEventHandlers = new List<EventHandler>();

        public NavigationFacade(Frame frame)
        {
            _frame = frame;
            _navigatedEventHandlers = new List<EventHandler<NavigationEventArgs>>();
        }

        public bool Navigate(Type page, string parameter) { return _frame.Navigate(page, parameter); }
        public void SetNavigationState(string state) { _frame.SetNavigationState(state); }
        public string GetNavigationState() { return _frame.GetNavigationState(); }
        public int BackStackDepth { get { return _frame.BackStackDepth; } }
        public bool CanGoBack { get { return _frame.CanGoBack; } }
        public void GoBack() { _frame.GoBack(); }
        public object Content { get { return _frame.Content; } }
        public object GetValue(DependencyProperty dp) { return _frame.GetValue(dp); }
        public void SetValue(DependencyProperty dp, object value) { _frame.SetValue(dp, value); }
        public void ClearValue(DependencyProperty dp) { _frame.ClearValue(dp); }

        public event EventHandler<NavigationEventArgs> Navigated
        {
            add
            {
                if (!_navigatedEventHandlers.Contains(value))
                {
                    _navigatedEventHandlers.Add(value);
                    if (_navigatedEventHandlers.Count == 1)
                        _frame.Navigated += FacadeNavigatedEventHandler;
                }
            }

            remove
            {
                if (_navigatedEventHandlers.Contains(value))
                {
                    _navigatedEventHandlers.Remove(value);
                    if (_navigatedEventHandlers.Count == 0)
                        _frame.Navigated -= FacadeNavigatedEventHandler;
                }
            }
        }

        void FacadeNavigatedEventHandler(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            foreach (var handler in _navigatedEventHandlers)
            {
                var args = new NavigationEventArgs()
                {
                    NavigationMode = e.NavigationMode,
                    Parameter = (e.Parameter == null) ? string.Empty : e.Parameter.ToString()
                };
                handler(this, args);
            }
        }

        public event EventHandler Navigating
        {
            add
            {
                if (!_navigatingEventHandlers.Contains(value))
                {
                    _navigatingEventHandlers.Add(value);
                    if (_navigatingEventHandlers.Count == 1)
                        _frame.Navigating += FacadeNavigatingCancelEventHandler;
                }
            }

            remove
            {
                if (_navigatingEventHandlers.Contains(value))
                {
                    _navigatingEventHandlers.Remove(value);
                    if (_navigatingEventHandlers.Count == 0)
                        _frame.Navigating -= FacadeNavigatingCancelEventHandler;
                }
            }
        }

        private void FacadeNavigatingCancelEventHandler(object sender, NavigatingCancelEventArgs e)
        {
            foreach (var handler in _navigatingEventHandlers)
            {
                handler(this, new EventArgs());
            }
        }
    }

}
