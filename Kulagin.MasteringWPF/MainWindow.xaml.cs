using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Kulagin.MasteringWPF.ViewModels;


namespace Kulagin.MasteringWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }

        private void MainWindow_Closed(object sender, EventArgs e) {
        }

        #region Overrides of Window

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close ? ",
                                                      "Close Confirmation",
                                                      MessageBoxButton.OKCancel,
                                                      MessageBoxImage.Question);
            e.Cancel = result == MessageBoxResult.Cancel;
        }

        #endregion
    }
}
