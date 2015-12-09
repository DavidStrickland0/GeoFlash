using GeoFlash.Library.Localization;
using GeoFlash.Library.Model;
using GeoFlash.Pages;
using GeoFlash.PCL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using Xamarin.Forms; 

namespace GeoFlash
{
    public class App : Application
    {
        
        public App(IFlashCardData flashCardData,ResourceManager resourceManager)
        {
            if (Device.OS != TargetPlatform.WinPhone)
            {
               GeoFlash.PCL.Localization.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
               
                //GeoFlash.App = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
            // The root page of your application
            MainPage = new MainMenu(flashCardData);
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
