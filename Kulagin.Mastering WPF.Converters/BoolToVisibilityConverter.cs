using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.Mastering_WPF.Converters {

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : BaseVisibilityConverter, IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null || value.GetType() != typeof(bool)) return null;
            bool boolValue = IsInverted ? !(bool)value : (bool)value;

            return boolValue ? Visibility.Visible : FalseVisibilityValue;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null || value.GetType() != typeof(Visibility)) return null;

            bool isVisible = (Visibility)value == Visibility.Visible;

            return IsInverted ? !isVisible : isVisible;
        }
    }
}