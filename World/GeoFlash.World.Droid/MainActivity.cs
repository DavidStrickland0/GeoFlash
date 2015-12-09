using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GeoFlash.PCL.DependencyServices;
using Xamarin.Forms;
using Android.Content;

namespace GeoFlash.India.Droid
{
    [Activity(Label = "GeoFlash: World", Icon = "@drawable/worldicon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            var flashCardData = new GeoFlash.World.CardLibrary.FlashCardData();
            var resourceManager = GeoFlash.World.Localization.ResourceController.ResourceManager;
            LoadApplication(new App(flashCardData, resourceManager));
        }
    }
}

