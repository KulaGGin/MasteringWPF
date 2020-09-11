using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace Kulagin.MasteringWPF.Views.Panels {
    public class AnimatedStackPanel : Panel {

        public static DependencyProperty OrientationProperty = DependencyProperty.Register(
                                                                                      nameof(Orientation),
                                                                                      typeof(Orientation),
                                                                                      typeof(AnimatedStackPanel),
                                                                                      new PropertyMetadata(Orientation.Vertical)
                                                                                  );

        public Orientation Orientation { get { return (Orientation)GetValue(OrientationProperty); } set { SetValue(OrientationProperty, value); } }

        protected override Size MeasureOverride(Size availableSize) {
            double x = 0, y = 0;

            foreach (UIElement child in Children) {
                child.Measure(availableSize);

                if (Orientation == Orientation.Horizontal) {
                    x += child.DesiredSize.Width;
                    y = Math.Max(y, child.DesiredSize.Height);
                }
                else {
                    x = Math.Max(x, child.DesiredSize.Width);
                    y += child.DesiredSize.Height;
                }
            }

            return new Size(x, y);
        }

        protected override Size ArrangeOverride(Size finalSize) {
            Point endPosition = new Point();

            foreach (UIElement child in Children) {
                if (Orientation == Orientation.Horizontal) {
                    child.Arrange(new Rect(-child.DesiredSize.Width, 0, child.DesiredSize.Width, finalSize.Height));

                    endPosition.X += child.DesiredSize.Width;
                }
                else {
                    child.Arrange(new Rect(0, -child.DesiredSize.Height, finalSize.Width, child.DesiredSize.Height));

                    endPosition.Y += child.DesiredSize.Height;
                }

                AnimatePosition(child, endPosition, TimeSpan.FromMilliseconds(300));
            }

            return finalSize;
        }

        private void AnimatePosition(UIElement child, Point endPosition, TimeSpan animationDuration) {
            if (Orientation == Orientation.Vertical)
                GetTranslateTransform(child)
                    .BeginAnimation(TranslateTransform.YProperty, new DoubleAnimation(endPosition.Y, animationDuration));
            else
                GetTranslateTransform(child)
                    .BeginAnimation(TranslateTransform.XProperty, new DoubleAnimation(endPosition.X, animationDuration));
        }

        private TranslateTransform GetTranslateTransform(UIElement child) {
            return child.RenderTransform as TranslateTransform ?? AddTranslateTransform(child);
        }

        private TranslateTransform AddTranslateTransform(UIElement child) {
            TranslateTransform translateTransform = new TranslateTransform();
            child.RenderTransform = translateTransform;
            return translateTransform;
        }
    }
}