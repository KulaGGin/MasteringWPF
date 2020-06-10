using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Kulagin.Mastering_WPF.Views.Attached {
    public class ButtonProperties : Button {
        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.RegisterAttached("StrokeThickness",
                                                typeof(double), typeof(ButtonProperties),
                                                new FrameworkPropertyMetadata(default(double)));

        public static double GetStrokeThickness(DependencyObject dependencyObject) {
            return (double)dependencyObject.GetValue(StrokeThicknessProperty);
        }

        public static void SetStrokeThickness(DependencyObject dependencyObject, double thickness) {
            dependencyObject.SetValue(StrokeThicknessProperty, thickness);
        }
    }
}
