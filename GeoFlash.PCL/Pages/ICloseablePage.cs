using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFlash.Library.Pages
{
    public interface ICloseablePage
    {
        event EventHandler RequestClose;
    }
}
