using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Kulagin.Mastering_WPF.DataModels;
using Kulagin.Mastering_WPF.ViewModels.Business;
using Kulagin.Mastering_WPF.ViewModels.Interfaces;


namespace Kulagin.Mastering_WPF.ViewModels {
    public class UsersViewModel : BaseBusinessViewModel, IUserViewModel {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        private User _user;
        private bool isSelected = false;

        public UsersViewModel() {
            PopulateUsers();
        }

        public UsersViewModel(User user) {
            User = user;
        }

        public User User {
            get { return _user; }
            set {
                _user = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public Guid Id {
            get { return User.Id; }
            set {
                User.Id = value;
                NotifyPropertyChanged();
            }
        }

        public string Name {
            get { return User.Name; }
            set {
                User.Name = value;
                NotifyPropertyChanged();
            }
        }

        public int Age {
            get { return User.Age; }
            set {
                User.Age = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsSelected {
            get { return isSelected; }
            set {
                isSelected = value;
                NotifyPropertyChanged();
            }
        }

        private void PopulateUsers() {
            Users.Add(new User(Guid.NewGuid(), "James Smith", 25));
            Users.Add(new User(Guid.NewGuid(), "Robert Johnson", 53));
            Users.Add(new User(Guid.NewGuid(), "Maria Garcia", 32));
            Users.Add(new User(Guid.NewGuid(), "Jane Pearson", 41));
        }
    }
}