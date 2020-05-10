using System;
using Kulagin.Mastering_WPF.DataModels;


namespace Kulagin.Mastering_WPF.Models.Interfaces {
    public interface IDataProvider {
        User GetUser(Guid id);
        bool SaveUser(User user);
    }
}