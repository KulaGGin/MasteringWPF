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
using Kulagin.Mastering_WPF.DataModels;

namespace Kulagin.Mastering_WPF.Views.Controls {
    /// <summary>
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : UserControl {
        public AddressControl() {
            InitializeComponent();
        }
        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register(nameof(Address),
                                        typeof(Address), typeof(AddressControl),
                                        new PropertyMetadata(new Address()));
        public Address Address {
            get { return (Address)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }

    }
}
