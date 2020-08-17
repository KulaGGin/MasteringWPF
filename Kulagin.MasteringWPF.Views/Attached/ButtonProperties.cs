using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Kulagin.MasteringWPF.Views.Attached {
    public class ButtonProperties : DependencyObject {

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.RegisterAttached("StrokeThickness",
                                                                                                                typeof(double),
                                                                                                                typeof(ButtonProperties),
                                                                                                                new FrameworkPropertyMetadata((double)2.0M));

        public static double GetStrokeThickness(DependencyObject dependencyObject) {
            return (double)dependencyObject.GetValue(StrokeThicknessProperty);
        }

        public static void SetStrokeThickness(DependencyObject dependencyObject, double value) {
            dependencyObject.SetValue(StrokeThicknessProperty, value);
        }

    }
}
