using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Interfaces {
    public interface ISynchronizableDataModel<T> where T: class, new() {
        void CopyValuesFrom(T dataModel);
    }
}
