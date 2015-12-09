using GeoFlash.Library.Localization;
using Xamarin.Forms;
[assembly: Dependency(typeof(GeoFlash.India.Droid.Localize))]

namespace GeoFlash.India.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}