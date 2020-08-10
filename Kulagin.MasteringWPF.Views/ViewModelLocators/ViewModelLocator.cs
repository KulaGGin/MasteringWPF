using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kulagin.MasteringWPF.Managers;
using Kulagin.MasteringWPF.ViewModels.Interfaces;
using Kulagin.MasteringWPF.ViewModels.Mocks;


namespace Kulagin.MasteringWPF.Views.ViewModelLocators {
    class ViewModelLocator {
        private DependencyObject dependencyObject = new DependencyObject();

        public bool IsDesignTime {
            get { return DesignerProperties.GetIsInDesignMode(dependencyObject); }
        }

        public IUserViewModel UserViewModel {
            get {
                return IsDesignTime ? new MockUserViewModel() : DependencyManager.Instance.Resolve<IUserViewModel>();
            }
        }
    }
}
