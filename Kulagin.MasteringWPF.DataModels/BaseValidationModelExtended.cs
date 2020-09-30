using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class BaseValidationModelExtended :
        INotifyPropertyChanged, IDataErrorInfo {
        protected ObservableCollection<string> errors = new ObservableCollection<string>();
        protected ObservableCollection<string> externalErrors = new ObservableCollection<string>();

        protected BaseValidationModelExtended() {
            ExternalErrors.CollectionChanged += ExternalErrors_CollectionChanged;
        }

        public virtual ObservableCollection<string> Errors => errors;
        public ObservableCollection<string> ExternalErrors => externalErrors;
        public virtual bool HasError => errors != null && errors.Any();

        #region IDataErrorInfo Members

        public string Error {
            get {
                if (!HasError) return string.Empty;
                StringBuilder errors = new StringBuilder();
                Errors.ForEach(e => errors.AppendUniqueOnNewLineIfNotEmpty(e));
                return errors.ToString();
            }
        }

        public virtual string this[string propertyName] => string.Empty;

        #endregion

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(
            params string[] propertyNames) {
            if (PropertyChanged != null) {
                foreach (string propertyName in propertyNames) {
                    if (propertyName != nameof(HasError))
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasError)));
            }
        }

        protected virtual void NotifyPropertyChanged(
            [CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                if (propertyName != nameof(HasError))
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasError)));
            }
        }

        #endregion

        private void ExternalErrors_CollectionChanged(object sender,
                                                      NotifyCollectionChangedEventArgs e) =>
            NotifyPropertyChanged(nameof(Errors));
    }
}