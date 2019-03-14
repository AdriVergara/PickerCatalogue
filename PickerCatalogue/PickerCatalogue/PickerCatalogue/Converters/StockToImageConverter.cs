using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PickerCatalogue.Converters
{
    public class StockToImageConverter : IValueConverter //int to string
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (Equals(value, null))
                return "";

            int Stock = System.Convert.ToInt32(value);

            if (Stock >= 10)
            {
                return "StockGreen.png";
            }
            else if (Stock > 0)
            {
                return "StockYellow.png";
            }
            else
            {
                return "StockRed.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
