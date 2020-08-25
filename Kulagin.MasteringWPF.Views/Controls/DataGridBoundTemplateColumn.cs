using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Views.Controls {
    public class DataGridBoundTemplateColumn : DataGridTemplateColumn {
        public Binding Binding { get; set; }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem) {
            FrameworkElement element = base.GenerateElement(cell, dataItem);

            if(Binding != null)
                element.SetBinding(ContentPresenter.ContentProperty, Binding);

            return element;
        }
    }
}
