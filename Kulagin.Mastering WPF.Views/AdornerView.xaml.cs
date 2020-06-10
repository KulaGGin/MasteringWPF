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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kulagin.Mastering_WPF.Views.Adorners;


namespace Kulagin.Mastering_WPF.Views {
    /// <summary>
    /// Interaction logic for AdornerView.xaml
    /// </summary>
    public partial class AdornerView : UserControl {
        public AdornerView() {
            InitializeComponent();
            Loaded += AdornerView_Loaded;
        }

        private void AdornerView_Loaded(object sender, RoutedEventArgs e) {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(Canvas);
            foreach(UIElement uiElement in Canvas.Children) {
                adornerLayer.Add(new ResizeAdorner(uiElement));
            }
        }
    }
}
