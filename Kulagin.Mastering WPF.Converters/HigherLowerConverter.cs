using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.Mastering_WPF.Converters {
    public class HigherLowerConverter : IMultiValueConverter {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values == null || values.Length != 2 ||
                !(values[0] is int currentValue) || !(values[1] is int previousValue)) {

                return DependencyProperty.UnsetValue;
            }

            return currentValue > previousValue ? "->" : "<-";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            return new object[2] {DependencyProperty.UnsetValue, DependencyProperty.UnsetValue};
        }
    }
}