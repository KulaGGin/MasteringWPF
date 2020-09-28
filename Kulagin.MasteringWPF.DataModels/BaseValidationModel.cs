using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Annotations;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class BaseValidationModel : INotifyPropertyChanged, IDataErrorInfo {
        protected string error = string.Empty;
        #region IDataErrorInfo Members
        public string Error => error;
        public virtual string this[string propertyName] => error;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
