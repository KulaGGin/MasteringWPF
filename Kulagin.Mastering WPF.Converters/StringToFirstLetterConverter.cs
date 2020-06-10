using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.Mastering_WPF.Converters {
    [ValueConversion(typeof(string), typeof(string))]
    public class StringToFirstLetterConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) return DependencyProperty.UnsetValue;
            string stringValue = value.ToString();

            if (stringValue.Length < 1) return DependencyProperty.UnsetValue;

            return stringValue[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
