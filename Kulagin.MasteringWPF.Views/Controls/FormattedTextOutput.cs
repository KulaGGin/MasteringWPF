using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Kulagin.MasteringWPF.Views.Controls {
    public class FormattedTextOutput : FrameworkElement {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                                 nameof(Text),
                                 typeof(string),
                                 typeof(FormattedTextOutput),
                                 new FrameworkPropertyMetadata(
                                       string.Empty,
                                       FrameworkPropertyMetadataOptions.AffectsRender
                                     )
                               );

        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        protected override void OnRender(DrawingContext drawingContext) {
            DpiScale dpiScale = VisualTreeHelper.GetDpi(this);
            FormattedText formattedText = new FormattedText(Text,
                                                            CultureInfo.GetCultureInfo("en-us"),
                                                            FlowDirection.LeftToRight,
                                                            new Typeface("Times New Roman"),
                                                            50,
                                                            Brushes.Red,
                                                            dpiScale.PixelsPerDip);

            formattedText.SetFontStyle(FontStyles.Italic);
            formattedText.SetFontWeight(FontWeights.Bold);
            drawingContext.DrawText(formattedText, new Point(10, 0));
        }
    }
}