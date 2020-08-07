using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.ViewModels.Interfaces {
    /// <summary>
    /// Provides data for the UserView class.
    /// </summary>
    public interface IUserViewModel {
        /// <summary>
        /// Gets or sets the User object in the related View.
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// Gets or sets the ICommand object for the Save command in the related View.
        /// </summary>
        ICommand SaveCommand { get; }
    }
}
