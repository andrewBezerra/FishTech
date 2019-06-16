using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FishTechMobile.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ItemTappedEventArgs itemTappedEventArgs))
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));

            return itemTappedEventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
