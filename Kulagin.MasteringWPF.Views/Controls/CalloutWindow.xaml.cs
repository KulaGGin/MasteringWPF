using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Kulagin.MasteringWPF.Views.Controls {
    /// <summary>
    /// Interaction logic for CalloutWindow.xaml
    /// </summary>
    public partial class CalloutWindow : Window {

        static CalloutWindow() {
            BorderBrushProperty.OverrideMetadata(
                                                 typeof(CalloutWindow),
                                                 new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 238, 156, 88))));

            HorizontalContentAlignmentProperty.OverrideMetadata(
                                                                typeof(CalloutWindow),
                                                                new FrameworkPropertyMetadata(HorizontalAlignment.Center));
            VerticalContentAlignmentProperty.OverrideMetadata(
                                                              typeof(CalloutWindow),
                                                              new FrameworkPropertyMetadata(VerticalAlignment.Center));
        }

        public CalloutWindow() {
            InitializeComponent();
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register(nameof(Background),
                                        typeof(Brush),
                                        typeof(CalloutWindow),
                                        new PropertyMetadata(new LinearGradientBrush(Colors.White, Color.FromArgb(255, 250, 191, 143), 90)));

        public new Brush Background {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
    }
}
