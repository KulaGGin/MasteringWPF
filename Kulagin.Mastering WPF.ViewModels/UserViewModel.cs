using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.Mastering_WPF.DataModels;
using Kulagin.Mastering_WPF.ViewModels.Business;


namespace Kulagin.Mastering_WPF.ViewModels {
    public class UserViewModel : BaseBusinessViewModel {
        private User model;
        private bool isSelected = false;
        public UserViewModel(User model) {
            Model = model;
        }
        public User Model {
            get { return model; }
            set { model = value; NotifyPropertyChanged(); }
        }
        public Guid Id {
            get { return Model.Id; }
            set { Model.Id = value; NotifyPropertyChanged(); }
        }
        public string Name {
            get { return Model.Name; }
            set { Model.Name = value; NotifyPropertyChanged(); }
        }
        public int Age {
            get { return Model.Age; }
            set { Model.Age = value; NotifyPropertyChanged(); }
        }
        public bool IsSelected {
            get { return isSelected; }
            set { isSelected = value; NotifyPropertyChanged(); }
        }
    }
}
