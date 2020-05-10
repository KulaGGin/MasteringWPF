using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
