using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Kulagin.MasteringWPF.CustomControls {
    public class Gauge : Control {
        static Gauge() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Gauge), new FrameworkPropertyMetadata(typeof(Gauge)));
        }

        public static readonly DependencyPropertyKey valueAnglePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(ValueAngle), typeof(double), typeof(Gauge), new PropertyMetadata(180.0));

        public static readonly DependencyProperty ValueAngleProperty = valueAnglePropertyKey.DependencyProperty;

        public double ValueAngle { get { return (double)GetValue(ValueAngleProperty); } private set { SetValue(valueAnglePropertyKey, value); } }

        public static readonly DependencyPropertyKey rotationAnglePropertyKey =
            DependencyProperty.RegisterReadOnly(nameof(RotationAngle), typeof(double), typeof(Gauge),
                                                new PropertyMetadata(180.0));

        public static readonly DependencyProperty RotationAngleProperty = rotationAnglePropertyKey.DependencyProperty;

        public double RotationAngle { get { return (double)GetValue(RotationAngleProperty); } private set { SetValue(rotationAnglePropertyKey, value); } }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(nameof(Value), typeof(double), typeof(Gauge),
                                                                                              new PropertyMetadata(0.0, OnValueChanged));

        private static void OnValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
            Gauge gauge = (Gauge)dependencyObject;

            if (gauge.MaximumValue == 0.0)
                gauge.ValueAngle = gauge.RotationAngle = 180.0;
            else if ((double)e.NewValue > gauge.MaximumValue) {
                gauge.ValueAngle = 0.0;
                gauge.RotationAngle = 360.0;
            }
            else {
                double scaledPercentageValue = ((double)e.NewValue / gauge.MaximumValue) * 180.0;

                gauge.ValueAngle = 180.0 - scaledPercentageValue;
                gauge.RotationAngle = 180.0 + scaledPercentageValue;
            }
        }

        public double Value { get { return (double)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }

        public static readonly DependencyProperty MaximumValueProperty = DependencyProperty.Register(nameof(MaximumValue), typeof(double), typeof(Gauge),
                                                                                                     new PropertyMetadata(0.0));

        public double MaximumValue { get { return (double)GetValue(MaximumValueProperty); } set { SetValue(MaximumValueProperty, value); } }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(Gauge),
                                                                                              new PropertyMetadata(string.Empty));

        public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
    }
}