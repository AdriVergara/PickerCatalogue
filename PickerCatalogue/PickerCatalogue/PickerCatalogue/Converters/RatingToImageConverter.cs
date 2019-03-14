using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PickerCatalogue.Converters
{
    public class RatingToImageConverter : IValueConverter //int to string
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (Equals(value, null))
                return "";

            double Rating = System.Convert.ToDouble(value);

            if (Rating < 3.5)
            {
                return "Rating3stars.png";
            }
            else if (Rating < 4.5)
            {
                return "Rating4stars.png";
            }
            else
            {
                return "Rating5stars.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
