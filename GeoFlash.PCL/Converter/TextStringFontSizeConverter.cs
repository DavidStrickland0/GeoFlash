using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GeoFlash
{
	public class TextStringFontSizeConverter : IValueConverter
    {
		int mediumLength =0;
		public TextStringFontSizeConverter(int mediumLength)
        {
			this.mediumLength = mediumLength;
        }

        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
			if(value.ToString().Length <=this.mediumLength)
				return Device.GetNamedSize(NamedSize.Medium, typeof(Button));
			else
				return Device.GetNamedSize(NamedSize.Small, typeof(Button));

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
