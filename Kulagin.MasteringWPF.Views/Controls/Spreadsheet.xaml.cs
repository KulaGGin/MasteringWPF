using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.Views.Controls {
    /// <summary>
    /// Interaction logic for Spreadsheet.xaml
    /// </summary>
    public partial class Spreadsheet : DataGrid {
        public Spreadsheet() {
            InitializeComponent();
        }

        protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue) {
            if(!(newValue is DataRowCollection rows) || rows.Count == 0)
                return;

            Cell[] cells = rows[0].ItemArray.Cast<Cell>().ToArray();
            Columns.Clear();

            DataTemplate cellTemplate = (DataTemplate)FindResource("CellTemplate");
            for(int i = 0; i < cells.Length; i++) {
                DataGridBoundTemplateColumn column = new DataGridBoundTemplateColumn {
                                                             Header = GetColumnName(i + 1),
                                                             CellTemplate = cellTemplate,
                                                             Binding = new Binding($"[{i}]"),
                                                             Width = cells[i].Width
                                                         };
                Columns.Add(column);
            }
        }
        private string GetColumnName(int index) {
            if(index <= 26)
                return ((char)(index + 64)).ToString();

            if(index % 26 == 0)
                return string.Concat(GetColumnName(index / 26 - 1), "Z");

            return string.Concat(GetColumnName(index / 26), GetColumnName(index % 26));
        }
    }
}
