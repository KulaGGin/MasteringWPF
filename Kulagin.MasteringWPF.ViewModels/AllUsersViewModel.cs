using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.ViewModels {
    /// <summary>
    /// A View Model that is paired with the AllUsersView class, to display the various User-related examples from the book.
    /// </summary>
    public class AllUsersViewModel : BaseViewModel {
        private ObservableCollection<User> users = null;

        /// <summary>
        /// Initializes a new AllUsersViewModel instance.
        /// </summary>
        public AllUsersViewModel() {
            PopulateUsers();
        }

        /// <summary>
        /// Gets or sets the collection of User objects to display in the View.
        /// </summary>
        public ObservableCollection<User> Users {
            get { return users; }
            set { if(users != value) { users = value; NotifyPropertyChanged(); } }
        }

        private void PopulateUsers() {
            Users = new ObservableCollection<User>();
            Users.Add(new User(Guid.NewGuid(), "James Smith", 25));
            Users.Add(new User(Guid.NewGuid(), "Robert Johnson", 53));
            Users.Add(new User(Guid.NewGuid(), "Maria Garcia", 32));
        }

    }
}
