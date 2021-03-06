﻿using System;
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

        private static readonly DependencyPropertyKey originalToolTipPropertyKey = DependencyProperty.RegisterAttachedReadOnly(
                                                                                                       "OriginalToolTip",
                                                                                                       typeof(string), typeof(ButtonProperties),
                                                                                                       new FrameworkPropertyMetadata(default(string))
                                                                                                      );

        public static readonly DependencyProperty OriginalToolTipProperty = originalToolTipPropertyKey.DependencyProperty;

        public static DependencyProperty DisabledToolTipProperty = DependencyProperty.RegisterAttached(
                                                                                       "DisabledToolTip",
                                                                                       typeof(string), typeof(ButtonProperties),
                                                                                       new UIPropertyMetadata(string.Empty, OnDisabledToolTipChanged)
                                                                                      );

        public static double GetStrokeThickness(DependencyObject dependencyObject) {
            return (double)dependencyObject.GetValue(StrokeThicknessProperty);
        }

        public static void SetStrokeThickness(DependencyObject dependencyObject, double value) {
            dependencyObject.SetValue(StrokeThicknessProperty, value);
        }

        public static string GetOriginalToolTip(DependencyObject dependencyObject) {
            return (string)dependencyObject.GetValue(OriginalToolTipProperty);
        }

        public static string GetDisabledToolTip(DependencyObject dependencyObject) {
            return (string)dependencyObject.GetValue(DisabledToolTipProperty);
        }

        public static void SetDisabledToolTip(DependencyObject dependencyObject, string value) {
            dependencyObject.SetValue(DisabledToolTipProperty, value);
        }

        private static void OnDisabledToolTipChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
            Button button = dependencyObject as Button;

            ToolTipService.SetShowOnDisabled(button, true);

            if (e.OldValue == null && e.NewValue != null)
                button.IsEnabledChanged += Button_IsEnabledChanged;
            else if (e.OldValue != null && e.NewValue == null)
                button.IsEnabledChanged -= Button_IsEnabledChanged;
        }

        private static void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) {
            Button button = sender as Button;

            if(GetOriginalToolTip(button) == null)
                button.SetValue(originalToolTipPropertyKey, button.ToolTip.ToString());

            button.ToolTip = (bool)e.NewValue ? GetOriginalToolTip(button) : GetDisabledToolTip(button);
        }
    }
}
