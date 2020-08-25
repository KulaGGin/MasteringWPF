using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {
    [ValueConversion(typeof(DataGridRow), typeof(int))]
    public class DataGridRowToRowNumberConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is DataGridRow dataGridRow)
                return dataGridRow.GetIndex() + 1;

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}