using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.ViewModels.Commands;
using Kulagin.MasteringWPF.ViewModels.Interfaces;


namespace Kulagin.MasteringWPF.ViewModels {
    /// <summary>
    /// Provides a pre-populated User object to the UI to demonstrate the use of View Model location.
    /// </summary>
    public class UserViewModel : BaseViewModel, IUserViewModel {
        private User user = new User(Guid.NewGuid(), "James Smith", 25) { Address = new Address() { HouseAndStreet = "147 Lucile Street", Town = "Somertown", City = "London", PostCode = "NW17 9RL", Country = "England" } };

        /// <summary>
        /// Gets or sets the User object to be used to demonstrate the use of View Model location with.
        /// </summary>
        public User User {
            get { return user; }
            set { user = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// The fictional save command to demonstrate the use of commanding with.
        /// </summary>
        public ICommand SaveCommand {
            get { return new ActionCommand(action => Save()); }
        }

        private void Save() {
            // Save User object
        }
    }
}
