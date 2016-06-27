using MyMonkeys.ViewModels;
using MyMonkeys.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyMonkeys
{
    public static class ViewModelLocator
    {
        static MonkeysViewModel monkeysVM;
        public static MonkeysViewModel MonkeysViewModel
        => monkeysVM ?? (monkeysVM = new MonkeysViewModel());

        //static DetailsViewModel detailsVM;
        //public static DetailsViewModel DetailsViewModel
        //=> detailsVM ?? (detailsVM = new DetailsViewModel(MonkeyHelper.Monkeys[0]));
    }

    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};

            MainPage = new NavigationPage(new MonkeysPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#2196F3")
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
