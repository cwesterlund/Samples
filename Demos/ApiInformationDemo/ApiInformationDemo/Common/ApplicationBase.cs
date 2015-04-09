using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ApiInformationDemo.Common
{
    public abstract partial class ApplicationBase : Application
    {
        public ApplicationBase()
        {
            this.Resuming += (s, e) => HandleResuming(s, e);
            this.Suspending += async (s, e) =>
            {
                var deferral = e.SuspendingOperation.GetDeferral();
                await HandleSuspendingAsync(s, e);
                deferral.Complete();
            };
        }

        public Services.NavigationService NavigationService { get; private set; }

        protected virtual void HandleResuming(object s, object e) { }
        protected virtual Task HandleSuspendingAsync(object s, SuspendingEventArgs e) { return Task.FromResult<object>(null); }

        public Frame RootFrame { get; private set; }
        protected Action<Page> SplashFactory { get; set; }
        protected virtual Task OnInitializeAsync() { return Task.FromResult<object>(null); }

        protected virtual Task OnActivatedByProtocolAsync(ProtocolActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnActivatedByPrimaryTileAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnActivatedBySecondaryTileAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnActivatedByToastNotificationAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }

        protected override async void OnActivated(IActivatedEventArgs e)
        {
            switch (e.Kind)
            {
                case ActivationKind.Launch:
                    var args = e as LaunchActivatedEventArgs;
                    if (args.TileId == "App")
                    {
                        await OnActivatedByPrimaryTileAsync(args);
                    }
                    else if (args.Arguments.Any())
                    {
                        await OnActivatedBySecondaryTileAsync(args);
                    }
                    else
                    {
                        await OnActivatedByToastNotificationAsync(args);
                    }
                    break;
                case ActivationKind.Protocol:
                case ActivationKind.ProtocolForResults:
                case ActivationKind.ProtocolWithResultsContinuation:
                    await OnActivatedByProtocolAsync(e as ProtocolActivatedEventArgs);
                    break;
                case ActivationKind.Search:
                case ActivationKind.ShareTarget:
                case ActivationKind.File:
                case ActivationKind.FileOpenPicker:
                case ActivationKind.FileSavePicker:
                case ActivationKind.CachedFileUpdater:
                case ActivationKind.ContactPicker:
                case ActivationKind.Device:
                case ActivationKind.PrintTaskSettings:
                case ActivationKind.CameraSettings:
                case ActivationKind.RestrictedLaunch:
                case ActivationKind.AppointmentsProvider:
                case ActivationKind.Contact:
                case ActivationKind.LockScreenCall:
                case ActivationKind.VoiceCommand:
                case ActivationKind.LockScreen:
                case ActivationKind.PickerReturned:
                case ActivationKind.WalletAction:
                case ActivationKind.PickFileContinuation:
                case ActivationKind.PickSaveFileContinuation:
                case ActivationKind.PickFolderContinuation:
                case ActivationKind.WebAuthenticationBrokerContinuation:
                case ActivationKind.WebAccountProvider:
                case ActivationKind.ComponentUI:
                    throw new NotImplementedException(string.Format("{0}. Override OnActivated()", e.Kind));
            }
            Window.Current.Activate();
        }

        protected virtual Task OnLaunchedByProtocolAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnLaunchedByPrimaryTileAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnLaunchedBySecondaryTileAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }
        protected virtual Task OnLaunchedByToastNotificationAsync(LaunchActivatedEventArgs e) { return Task.FromResult<object>(null); }

        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await OnInitializeAsync();
            this.RootFrame = Window.Current.Content as Frame;
            if (this.RootFrame == null)
            {
                this.RootFrame = new Frame();
                this.RootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
                Window.Current.Content = this.RootFrame;
            }

            this.NavigationService = new Services.NavigationService(this.RootFrame);

            switch (e.Kind)
            {
                case ActivationKind.Launch:
                    if (e.TileId == "App")
                    {
                        await OnLaunchedByPrimaryTileAsync(e);
                    }
                    else if (e.Arguments.Any())
                    {
                        await OnLaunchedByToastNotificationAsync(e);
                    }
                    else
                    {
                        await OnLaunchedBySecondaryTileAsync(e);
                    }
                    break;
                case ActivationKind.Protocol:
                    await OnLaunchedByProtocolAsync(e);
                    break;
                case ActivationKind.Search:
                case ActivationKind.ShareTarget:
                case ActivationKind.File:
                case ActivationKind.FileOpenPicker:
                case ActivationKind.FileSavePicker:
                case ActivationKind.CachedFileUpdater:
                case ActivationKind.ContactPicker:
                case ActivationKind.Device:
                case ActivationKind.PrintTaskSettings:
                case ActivationKind.CameraSettings:
                case ActivationKind.RestrictedLaunch:
                case ActivationKind.AppointmentsProvider:
                case ActivationKind.Contact:
                case ActivationKind.LockScreenCall:
                case ActivationKind.VoiceCommand:
                case ActivationKind.LockScreen:
                case ActivationKind.PickerReturned:
                case ActivationKind.WalletAction:
                case ActivationKind.PickFileContinuation:
                case ActivationKind.PickSaveFileContinuation:
                case ActivationKind.PickFolderContinuation:
                case ActivationKind.WebAuthenticationBrokerContinuation:
                case ActivationKind.WebAccountProvider:
                case ActivationKind.ComponentUI:
                case ActivationKind.ProtocolWithResultsContinuation:
                case ActivationKind.ProtocolForResults:
                    throw new NotImplementedException(string.Format("{0}. Override OnLaunched()", e.Kind));
            }
            Window.Current.Activate();
        }
    }
}
