using Cookbook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Cookbook.ViewModels;
using Cookbook.ObjectModels;
using Windows.UI.ViewManagement;
using Windows.UI.Core;


namespace Cookbook
{
    
    sealed partial class App : Application
    {
        
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

       
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseCoreWindow);
         
            Frame rootFrame = Window.Current.Content as Frame;
            Windows.UI.Color lightTheme = new Windows.UI.Color();
            Windows.UI.Color darkTheme = new Windows.UI.Color();
            lightTheme = Windows.UI.Color.FromArgb(200, 237, 223, 192);
            darkTheme = Windows.UI.Color.FromArgb(200, 95, 71, 73);
            
            var titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonForegroundColor = darkTheme;
            titleBar.ButtonBackgroundColor = lightTheme;
            titleBar.ButtonHoverBackgroundColor = darkTheme;
            titleBar.ButtonHoverForegroundColor = lightTheme;
            titleBar.ButtonPressedBackgroundColor = lightTheme;
            titleBar.ButtonPressedForegroundColor = darkTheme;
            titleBar.BackgroundColor = lightTheme;
            
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, f) =>
            {
                if (rootFrame.CanGoBack)
                    f.Handled = true;
                    rootFrame.GoBack();
            };
            
            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

              
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                
                
                rootFrame.Navigate(typeof(Categories), e.Arguments);
            }
            
            Window.Current.Activate();
        }

      
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

       
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            
            deferral.Complete();
        }

       
    }
}
