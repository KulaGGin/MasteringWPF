using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {
    public class DataGridColumnHeaderSelectionMultiConverter : IMultiValueConverter {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values == null || values.Count() != 2 || values.Any(v => v == null || v == DependencyProperty.UnsetValue))
                return false;

            string selectedColumnHeader = values[0].ToString();
            string columnHeaderToCompare = values[1].ToString();

            return selectedColumnHeader.Equals(columnHeaderToCompare);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}