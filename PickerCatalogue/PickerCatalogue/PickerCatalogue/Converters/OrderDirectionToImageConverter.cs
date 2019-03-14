using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PickerCatalogue.Converters
{
    public class OrderDirectionToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (Equals(value, null))
                return "";

            int Order = System.Convert.ToInt32(value);

            if (Order == 1)
            {
                return "ArrowUp.png";
            }
            else
            {
                return "ArrowDown.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
