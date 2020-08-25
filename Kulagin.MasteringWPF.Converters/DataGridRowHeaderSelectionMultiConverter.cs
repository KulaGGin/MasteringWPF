using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {
    public class DataGridRowHeaderSelectionMultiConverter : IMultiValueConverter {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values == null || values.Count() != 2 ||
                !(values[0] is DataRow selectedDataRow) ||
                !(values[1] is DataRow dataRowToCompare))
                return false;

            return selectedDataRow.Equals(dataRowToCompare);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}