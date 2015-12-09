using Android.App;
using Android.Content;
using Android.OS;
using GeoFlash.PCL.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: Xamarin.Forms.Dependency(typeof(VibratorService))]
namespace GeoFlash.PCL.DependencyServices
{
    public class VibratorService : IVibrator
    {
        public VibratorService()
        {

            vibrator = (Vibrator)Android.App.Application.Context.GetSystemService(Context.VibratorService);
        }

        internal Android.OS.Vibrator vibrator;
        public void Vibrate(int duration)
        {
            vibrator.Vibrate(duration);
        }


    }
}
