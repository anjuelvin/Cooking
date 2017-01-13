﻿using Cookbook.ObjectModels;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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


namespace Cookbook
{
 
    public sealed partial class RecipeInstructions : Page
    {
        private RecipeInstructionsViewModel recipeInstructionsViewModel;
        
        public RecipeInstructions()
        {
            this.InitializeComponent();
            this.recipeInstructionsViewModel = new RecipeInstructionsViewModel();
        }

        

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            RecipeModel recipeModel = e.Parameter as RecipeModel;
            if (recipeModel != null)
            {
                await recipeInstructionsViewModel.GetRecipeAndInstructions(recipeModel.Title);
                this.DataContext = recipeInstructionsViewModel.Recipe;
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
