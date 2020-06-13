using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kulagin.Mastering_WPF.Managers;
using Kulagin.Mastering_WPF.ViewModels.Interfaces;


namespace Kulagin.Mastering_WPF.Views.ViewModelLocators {
    public class UserViewModelLocator : BaseViewModelLocator<IUserViewModel> {
        /// <summary>
        /// Initializes a new UserViewModelLocator control with default values.
        /// </summary>
        public UserViewModelLocator() {
            DesignTimeViewModel = new UserViewModel();
        }
    }
}