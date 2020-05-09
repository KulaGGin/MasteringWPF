using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.Mastering_WPF.DataModels.Enums;


namespace Kulagin.Mastering_WPF.DataModels.Interfaces {
    public interface ISynchronizableDataModel<T> where T : class, new() {
        
        ObjectState ObjectState { get; set; }

        bool HasChanges { get; }

        bool IsSynchronized { get; }

        void RevertState();

        void Synchronize();

        bool PropertiesEqual(T dataModel);

        void CopyValuesFrom(T dataModel);

        T Clone();
    }
}
