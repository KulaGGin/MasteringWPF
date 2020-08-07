using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Interfaces;
using Kulagin.MasteringWPF.Models.Interfaces;


namespace Kulagin.MasteringWPF.Models.DataControllers {
    public class DataController {
        private IDataProvider dataProvider;

        public User CurrentUser { get; set; }

        public DataController(IDataProvider dataProvider, User currentUser) {
            DataProvider = dataProvider;
            CurrentUser = currentUser;
        }

        protected IDataProvider DataProvider { get { return dataProvider; } private set { dataProvider = value; } }

        public User GetUser(Guid id) {
            return DataProvider.GetUser(id);
        }

        public bool AddUser(User user) {
            return DataProvider.AddUser(SetAuditCreateFields(user));
        }

        public bool SaveUser(User user) {
            return DataProvider.SaveUser(SetAuditUpdateFields(user));
        }

        private T SetAuditCreateFields<T>(T dataModel) where T : IAuditable {
            dataModel.Auditable.CreatedOn = DateTime.Now;
            dataModel.Auditable.CreatedBy = CurrentUser;
            return dataModel;
        }

        private T SetAuditUpdateFields<T>(T dataModel) where T : IAuditable {
            dataModel.Auditable.UpdatedOn = DateTime.Now;
            dataModel.Auditable.UpdatedBy = CurrentUser;
            return dataModel;
        }
    }
}
