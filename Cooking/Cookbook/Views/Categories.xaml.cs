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
using System.Threading.Tasks;
using Cookbook.ObjectModels;
using System.Collections.ObjectModel;
using Cookbook.ViewModels;
using Windows.UI.Core;
using Windows.Foundation.Metadata;



namespace Cookbook
{
  
    public sealed partial class Categories : Page
    {
        private CategoriesViewModel categoriesViewModel;

        public Categories()
        {
            this.InitializeComponent();
            this.categoriesViewModel = new CategoriesViewModel();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        public CategoriesViewModel CategoriesViewModel
        {
            get { return this.categoriesViewModel; }
        }

        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            await categoriesViewModel.GetAllCategoriesAsync();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }
            this.DataContext = categoriesViewModel;

           
            if (Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

        }
        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Categories));
        }

        private void RecipesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Recipes));
        }

        private void AboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Aboutus));
        }

        private void ContactUsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ContactUs));
        }
        private void TermsandconditionsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Termsandconditions));
        }
    }
}
