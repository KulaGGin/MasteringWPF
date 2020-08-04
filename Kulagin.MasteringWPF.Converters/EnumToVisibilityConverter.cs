using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public class EnumToVisibilityConverter : BaseVisibilityConverter, IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(value == null ||
               (value.GetType() != typeof(Enum) && value.GetType().BaseType != typeof(Enum))
               || parameter == null)
                return DependencyProperty.UnsetValue;

            string enumValue = value.ToString();
            string targetValue = parameter.ToString();

            bool boolValue = enumValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);

            boolValue = IsInverted ? !boolValue : boolValue;

            return boolValue ? Visibility.Visible : FalseVisibilityValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {

            if(value == null || value.GetType() != typeof(Visibility) || parameter == null)
                return DependencyProperty.UnsetValue;

            Visibility usedValue = (Visibility)value;

            string targetValue = parameter.ToString();

            if(IsInverted && usedValue != Visibility.Visible)
                return Enum.Parse(targetType, targetValue);
            else if(!IsInverted && usedValue == Visibility.Visible)
                return Enum.Parse(targetType, targetValue);
            else 
                return DependencyProperty.UnsetValue;
        }
    }
}
