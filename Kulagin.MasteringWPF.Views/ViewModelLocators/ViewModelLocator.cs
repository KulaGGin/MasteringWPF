using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.Managers;
using Kulagin.MasteringWPF.ViewModels.Interfaces;


namespace Kulagin.MasteringWPF.Views.ViewModelLocators {
    class ViewModelLocator {
        public IUserViewModel UserViewModel {
            get { return DependencyManager.Instance.Resolve<IUserViewModel>(); }
        }
    }
}
