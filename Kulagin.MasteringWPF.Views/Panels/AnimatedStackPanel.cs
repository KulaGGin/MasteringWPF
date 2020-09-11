using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using Kulagin.MasteringWPF.DataModels.Enums;
using Animatable = Kulagin.MasteringWPF.DataModels.Animatable;
using IAnimatable = Kulagin.MasteringWPF.DataModels.Interfaces.IAnimatable;


namespace Kulagin.MasteringWPF.Views.Panels {
    public class AnimatedStackPanel : Panel {

        private List<UIElement> elementsToBeRemoved = new List<UIElement>();

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

                BeginAnimations(child, finalSize, endPosition);
            }

            return finalSize;
        }

        private void BeginAnimations(UIElement child, Size finalSize, Point endPosition) {
            FrameworkElement frameworkChild = (FrameworkElement)child;

            if (frameworkChild.DataContext is IAnimatable) {
                Animatable animatable = ((IAnimatable)frameworkChild.DataContext).Animatable;

                animatable.OnRemovalStatusChanged -= Item_OnRemovalStatusChanged;
                animatable.OnRemovalStatusChanged += Item_OnRemovalStatusChanged;

                if (animatable.AdditionStatus == AdditionStatus.DoNotAnimate) {
                    child.Arrange(new Rect(endPosition.X, endPosition.Y, frameworkChild.ActualWidth, frameworkChild.ActualHeight));
                }
                else if (animatable.AdditionStatus == AdditionStatus.ReadyToAnimate) {
                    AnimateEntry(child, endPosition);
                    animatable.AdditionStatus = AdditionStatus.Added;
                    animatable.TransitionStatus = TransitionStatus.ReadyToAnimate;
                }
                else if (animatable.RemovalStatus == RemovalStatus.ReadyToAnimate)
                    AnimateExit(child, endPosition, finalSize);
                else if (animatable.TransitionStatus == TransitionStatus.ReadyToAnimate)
                    AnimateTransition(child, endPosition);
            }
        }

        private void Item_OnRemovalStatusChanged(object sender, EventArgs e) {
            if (((Animatable)sender).RemovalStatus == RemovalStatus.ReadyToAnimate)
                InvalidateArrange();
        }

        private void AnimateEntry(UIElement child, Point endPosition) {
            AnimatePosition(child, endPosition, TimeSpan.FromMilliseconds(300));
        }

        private void AnimateTransition(UIElement child, Point endPosition) {
            AnimatePosition(child, endPosition, TimeSpan.FromMilliseconds(300));
        }

        private void AnimateExit(UIElement child, Point startPosition, Size finalSize) {
            SetZIndex(child, 100);
            Point endPosition = new Point(startPosition.X + finalSize.Width, startPosition.Y);

            AnimatePosition(child, startPosition, endPosition, TimeSpan.FromMilliseconds(300), RemovalAnimation_Completed);

            elementsToBeRemoved.Add(child);
        }

        private void AnimatePosition(UIElement child, Point startPosition, Point endPosition, TimeSpan animationDuration, EventHandler animationCompletedHandler) {
            if (startPosition.X != endPosition.X) {
                DoubleAnimation xAnimation = new DoubleAnimation(startPosition.X, endPosition.X, animationDuration);

                xAnimation.AccelerationRatio = 1.0;

                if (animationCompletedHandler != null)
                    xAnimation.Completed += animationCompletedHandler;

                GetTranslateTransform(child).BeginAnimation(TranslateTransform.XProperty, xAnimation);
            }

            if (startPosition.Y != endPosition.Y) {
                DoubleAnimation yAnimation = new DoubleAnimation(startPosition.Y, endPosition.Y, animationDuration);

                yAnimation.AccelerationRatio = 1.0;

                if (startPosition.X == endPosition.X && animationCompletedHandler != null)
                    yAnimation.Completed += animationCompletedHandler;

                GetTranslateTransform(child).BeginAnimation(TranslateTransform.YProperty, yAnimation);
            }
        }

        private void RemovalAnimation_Completed(object sender, EventArgs e) {
            for (int index = elementsToBeRemoved.Count - 1; index >= 0; index--) {
                FrameworkElement frameworkElement = elementsToBeRemoved[index] as FrameworkElement;

                if (frameworkElement.DataContext is IAnimatable) {
                    ((IAnimatable)frameworkElement.DataContext).Animatable.RemovalStatus = RemovalStatus.ReadyToRemove;

                    elementsToBeRemoved.Remove(frameworkElement);
                }
            }
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