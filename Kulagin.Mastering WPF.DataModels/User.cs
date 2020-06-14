using System;


namespace Kulagin.Mastering_WPF.DataModels {
    public class User : BaseDataModel {
        Address address = new Address();
        private string name = string.Empty;
        private int age = 0;

        public User() {
        }

        /// <summary>
        /// Gets or sets the address of the User object encapsulated in an Address object.
        /// </summary>
        public Address Address {
            get { return address; }
            set { address = value; NotifyPropertyChanged(); }
        }

        public User(Guid id, string name, int age) {
            Id = id;
            Name = name;
            Age = age;
        }

        public Guid Id { get; set; }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }
        public int Age { get { return age; } set { age = value; NotifyPropertyChanged(); } }

        public override string ToString() {
            return Name;
        }
    }
}