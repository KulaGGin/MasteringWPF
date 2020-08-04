using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Annotations;


namespace Kulagin.MasteringWPF.DataModels {
    public class BaseDataModel : INotifyPropertyChanged {
        private DateTime createdOn;
        private DateTime? updatedOn;
        private User createdBy, updatedBy;
        public DateTime CreatedOn {
            get { return createdOn; }
            set { createdOn = value; NotifyPropertyChanged(); }
        }
        public User CreatedBy {
            get { return createdBy; }
            set { createdBy = value; NotifyPropertyChanged(); }
        }
        public DateTime? UpdatedOn {
            get { return updatedOn; }
            set { updatedOn = value; NotifyPropertyChanged(); }
        }
        public User UpdatedBy {
            get { return updatedBy; }
            set { updatedBy = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
