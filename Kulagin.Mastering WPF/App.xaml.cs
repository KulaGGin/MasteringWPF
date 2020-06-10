using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kulagin.Mastering_WPF.Managers;
using Kulagin.Mastering_WPF.Models.DataProviders;
using Kulagin.Mastering_WPF.Models.Interfaces;
using Kulagin.Mastering_WPF.ViewModels;
using Kulagin.Mastering_WPF.ViewModels.Interfaces;


namespace Kulagin.Mastering_WPF {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public void App_Startup(object sender, StartupEventArgs e) {
            RegisterDependencies();
            new MainWindow().Show();
        }
        private void RegisterDependencies() {
            DependencyManager.Instance.ClearRegistrations();
            DependencyManager.Instance.Register<IDataProvider, MockDataProvider>();
            //DependencyManager.Instance.Register<IEmailManager, EmailManager>();
            //DependencyManager.Instance.Register<IExcelManager, ExcelManager>();
            //DependencyManager.Instance.Register<IWindowManager, WindowManager>();
        }
    }
}
