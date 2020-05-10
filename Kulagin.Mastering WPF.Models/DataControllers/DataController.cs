using System;
using Kulagin.Mastering_WPF.DataModels;
using Kulagin.Mastering_WPF.Models.Interfaces;


namespace Kulagin.Mastering_WPF.Models.DataControllers {
    public class DataController {

        private IDataProvider dataProvider;


        public DataController(IDataProvider dataProvider) {
            DataProvider = dataProvider;
        }


        protected IDataProvider DataProvider { get { return dataProvider; } private set { dataProvider = value; } }


        public User GetUser(Guid id) {
            return DataProvider.GetUser(id);
        }


        public bool SaveUser(User user) {
            return DataProvider.SaveUser(user);
        }
    }
}