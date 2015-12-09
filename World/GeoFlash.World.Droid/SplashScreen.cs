namespace GeoFlash.India.SplashScreen
{
    using System.Threading;

    using Android.App;
    using Android.OS;
    using Android.Content.PM;
    using GeoFlash.India.Droid;
	[Activity(Label="GeoFlash: World",Icon = "@drawable/worldicon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(MainActivity));
        }
    }
}