using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Kulagin.MasteringWPF.Views.Panels {
    namespace CompanyName.ApplicationName.Views.Panels {
        public class CircumferencePanel : Panel {
            public Thickness Padding { get; set; }

            protected override Size MeasureOverride(Size availableSize) {
                foreach (UIElement element in Children) {
                    element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                }

                return availableSize;
            }

            protected override Size ArrangeOverride(Size finalSize) {
                if (Children.Count == 0) return finalSize;
                double currentAngle = 90 * (Math.PI / 180);
                double radiansPerElement = (360 / Children.Count) * (Math.PI / 180.0);

                double radiusX = finalSize.Width / 2.0 - Padding.Left;
                double radiusY = finalSize.Height / 2.0 - Padding.Top;

                foreach (UIElement element in Children) {
                    Point childPoint = new Point(Math.Cos(currentAngle) * radiusX, -Math.Sin(currentAngle) * radiusY);

                    Point centeredChildPoint = new Point(childPoint.X + finalSize.Width / 2 - element.DesiredSize.Width / 2,
                                                         childPoint.Y + finalSize.Height / 2 - element.DesiredSize.Height / 2);

                    Rect boundingBox = new Rect(centeredChildPoint, element.DesiredSize);
                    element.Arrange(boundingBox);
                    currentAngle -= radiansPerElement;
                }

                return finalSize;
            }
        }
    }
}