using Cookbook.ObjectModels;
using Cookbook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//

namespace Cookbook
{
 
    public sealed partial class Recipes : Page
    {
        private RecipesViewModel recipesViewModel;

        public Recipes()
        {
            this.InitializeComponent();
            this.recipesViewModel = new RecipesViewModel();
        }


        public RecipesViewModel RecipesViewModel
        {
            get { return this.recipesViewModel; }
        }

       
        public object UniqueId { get; internal set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string categoryName = e.Parameter as string;

            if (categoryName != null)
            {
                await recipesViewModel.GetAllRecipesByCategoryAsync(categoryName);
                this.DataContext = recipesViewModel;
            }

            //Show UI Back button if necessary
            if (Frame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }

            //Memory Leak
            byte[] memoryLeak = new byte[10000000];
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Categories));
        }

        private void RecipesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Recipes));
        }
    }
}
