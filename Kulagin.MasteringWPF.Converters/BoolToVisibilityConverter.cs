using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : BaseVisibilityConverter, IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null || value.GetType() != typeof(bool))
                return DependencyProperty.UnsetValue;

            bool boolValue = IsInverted ? !(bool)value : (bool)value;

            return boolValue ? Visibility.Visible : FalseVisibilityValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null || value.GetType() != typeof(Visibility))
                return DependencyProperty.UnsetValue;

            if(IsInverted)
                return (Visibility)value != Visibility.Visible;

            return (Visibility)value == Visibility.Visible;
        }
    }
}
