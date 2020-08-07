using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Kulagin.MasteringWPF.Managers;
using Kulagin.MasteringWPF.Models.Interfaces;
using Kulagin.MasteringWPF.ViewModels;
using Kulagin.MasteringWPF.ViewModels.Interfaces;
using Test.Kulagin.MasteringWPF.Models.DataProviders;


namespace Kulagin.MasteringWPF {
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
            DependencyManager.Instance.Register<IUserViewModel, UserViewModel>();
            //DependencyManager.Instance.Register<IEmailManager, EmailManager>();
            //DependencyManager.Instance.Register<IExcelManager, ExcelManager>();
            //DependencyManager.Instance.Register<IWindowManager, WindowManager>();
        }
    }
}
