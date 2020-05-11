using System;
using Kulagin.Mastering_WPF.DataModels;
using Kulagin.Mastering_WPF.Models.Interfaces;


namespace Kulagin.Mastering_WPF.Models.DataProviders {
    public class MockDataProvider : IDataProvider {
        public User GetUser(Guid id) {
            return new User(id, "James Smith", 25);
        }

        public bool SaveUser(User user) {
            return true;
        }
    }
}