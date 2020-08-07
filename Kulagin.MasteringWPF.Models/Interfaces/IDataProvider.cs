using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.Models.Interfaces {
    public interface IDataProvider {
        User GetUser(Guid id);
        bool SaveUser(User user);
        bool AddUser(User user);
    }
}
