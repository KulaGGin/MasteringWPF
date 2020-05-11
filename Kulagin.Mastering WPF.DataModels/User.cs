using System;


namespace Kulagin.Mastering_WPF.DataModels {
    public class User {
        public User() {
        }

        public User(Guid id, string name, int age) {
            Id = id;
            Name = name;
            Age = age;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}