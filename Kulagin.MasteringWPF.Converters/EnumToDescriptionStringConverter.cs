using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.Converters {
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumToDescriptionStringConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null || (value.GetType() != typeof(Enum) && value.GetType().BaseType != typeof(Enum)))
                return DependencyProperty.UnsetValue;

            Enum enumInstance = (Enum)value;

            return enumInstance.GetDescription();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
