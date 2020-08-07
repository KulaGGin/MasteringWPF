using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Interfaces;


namespace Kulagin.MasteringWPF.DataModels {
    public class User : BaseSynchronizableDataModel<User>, IAuditable {
        private Address address = new Address();
        private Auditable auditable;
        private Guid id = Guid.Empty;
        private string name = string.Empty;
        private int age = 0;

        public User(Guid id, string name, int age) {
            Id = id;
            Name = name;
            Age = age;
        }

        public User() { }

        public Guid Id {
            get { return id; }
            set { if(id != value) { id = value; NotifyPropertyChanged(); } }
        }

        public string Name {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }

        public int Age {
            get { return age; }
            set { age = value; NotifyPropertyChanged(); }
        }

        public Address Address {
            get { return address; }
            set { address = value; NotifyPropertyChanged(); }
        }

        public Auditable Auditable {
            get { return auditable; }
            set { auditable = value; }
        }

        #region Overrides of BaseSynchronizableDataModel<User>

        public override void CopyValuesFrom(User user) {
            Id = user.Id;
            Name = user.Name;
            Age = user.Age;
        }

        public override bool PropertiesEqual(User otherUser) {
            if(otherUser == null) return false;
            return Id == otherUser.Id && Name == otherUser.Name && Age == otherUser.Age;
        }

        #endregion

    }
}
