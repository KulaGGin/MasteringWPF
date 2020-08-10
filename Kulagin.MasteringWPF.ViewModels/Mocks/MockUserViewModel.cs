using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.ViewModels;
using Kulagin.MasteringWPF.ViewModels.Commands;
using Kulagin.MasteringWPF.ViewModels.Interfaces;


namespace Kulagin.MasteringWPF.ViewModels.Mocks {
    public class MockUserViewModel : BaseViewModel, IUserViewModel {
        private User user = new User(Guid.NewGuid(), "James Smith", 25);

        public User User {
            get { return user; }
            set { user = value; NotifyPropertyChanged(); }
        }

        public ICommand SaveCommand {
            get { return new ActionCommand(action => Save()); }
        }

        private void Save() {
            // Save User object
        }
    }
}
