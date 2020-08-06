using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Annotations;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.DataModels {
    public class BaseDataModel : INotifyPropertyChanged {

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames) {
            if(PropertyChanged != null) propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
