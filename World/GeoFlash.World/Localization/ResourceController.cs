using GeoFlash.Library.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoFlash.World.Localization
{
    public class ResourceController
    {
        static  ResourceController()
        {
            GeoFlash.World.Localization.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
        }
        public static ResourceManager ResourceManager
        {
            get
            { 
                return GeoFlash.World.Localization.AppResources.ResourceManager;
            }
        }
    }
}
