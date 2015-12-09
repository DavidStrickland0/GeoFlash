using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFlash.PCL.DependencyServices
{
    public interface IVibrator
    {
        void Vibrate(int duration);
    }
}
