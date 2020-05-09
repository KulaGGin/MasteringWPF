using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.Mastering_WPF.DataModels.Interfaces {
    public interface ISynchronizableDataModel<T> where T : class, new() {

        void CopyValuesFrom(T dataModel);
    }
}
