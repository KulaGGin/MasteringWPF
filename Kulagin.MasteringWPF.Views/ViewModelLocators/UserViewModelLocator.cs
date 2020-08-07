using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.ViewModels;
using Kulagin.MasteringWPF.ViewModels.Interfaces;


namespace Kulagin.MasteringWPF.Views.ViewModelLocators {
    public class UserViewModelLocator : BaseViewModelLocator<IUserViewModel> {
        /// <summary>
        /// Initializes a new UserViewModelLocator control with default values.
        /// </summary>
        public UserViewModelLocator() {
            DesignTimeViewModel = new UserViewModel();
        }
    }
}
