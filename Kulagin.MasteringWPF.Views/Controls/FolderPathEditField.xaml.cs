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
using FolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace Kulagin.MasteringWPF.Views.Controls {
    /// <summary>
    /// Interaction logic for FolderPathEditField.xaml
    /// </summary>
    public partial class FolderPathEditField : UserControl {
        public FolderPathEditField() {
            InitializeComponent();
        }

        public static readonly DependencyProperty FolderPathProperty = DependencyProperty.Register(nameof(FolderPath), typeof(string), typeof(FolderPathEditField), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public string FolderPath {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        public static readonly DependencyProperty OpenFolderTitleProperty = DependencyProperty.Register(nameof(OpenFolderTitle), typeof(string), typeof(FolderPathEditField), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string OpenFolderTitle {
            get { return (string)GetValue(OpenFolderTitleProperty); }
            set { SetValue(OpenFolderTitleProperty, value); }
        }


        private void TextBox_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            if(((TextBox)sender).SelectedText.Length == 0 && e.GetPosition(this).X <= ((TextBox)sender).ActualWidth - SystemParameters.VerticalScrollBarWidth) ShowFolderPathEditWindow();
        }

        private void ShowFolderPathEditWindow() {
            string defaultFolderPath = string.IsNullOrEmpty(FolderPath) ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : FolderPath;
            string folderPath = ShowFolderBrowserDialog(defaultFolderPath);
            if(folderPath == string.Empty) return;
            FolderPath = folderPath;
        }

        private string ShowFolderBrowserDialog(string defaultFolderPath) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = OpenFolderTitle;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.SelectedPath = defaultFolderPath;
            folderBrowserDialog.ShowDialog();
            return folderBrowserDialog.SelectedPath;
        }
    }
}
