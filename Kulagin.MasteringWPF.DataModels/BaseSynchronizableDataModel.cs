using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Interfaces;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class BaseSynchronizableDataModel<T> : BaseDataModel, ISynchronizableDataModel<T> where T : BaseDataModel, ISynchronizableDataModel<T>, new() {
        private T originalState;
        public T OriginalState {
            get { return originalState; }
            private set { originalState = value; }
        }

        public abstract void CopyValuesFrom(T dataModel);

        public virtual T Clone() {
            T clone = new T();
            clone.CopyValuesFrom(this as T);
            return clone;
        }

        public abstract bool PropertiesEqual(T dataModel);

        public bool HasChanges {
            get { return originalState != null && !PropertiesEqual(originalState); }
        }

        public bool IsSynchronized { get; }

        public void Synchronize() {
            originalState = this.Clone();
            NotifyPropertyChanged(nameof(HasChanges));
        }
        public void RevertState() {
            Debug.Assert(originalState != null, "Object not yet synchronized.");
            CopyValuesFrom(originalState);
            Synchronize();
            NotifyPropertyChanged(nameof(HasChanges));
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// The event that is raised when a property that calls the NotifyPropertyChanged method is changed.
        /// </summary>
        public override event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event alerting the WPF Framework to update the UI.
        /// </summary>
        /// <param name="propertyNames">The names of the properties to update in the View.</param>
        protected override void NotifyPropertyChanged(params string[] propertyNames) {
            if(PropertyChanged != null) {
                foreach(string propertyName in propertyNames) {
                    if(propertyName != nameof(HasChanges)) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasChanges)));
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event alerting the WPF Framework to update the UI.
        /// </summary>
        /// <param name="propertyName">The optional name of the property to update in the View. If this is left blank, the name will be taken from the calling member via the CallerMemberName attribute.</param>
        protected override void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if(PropertyChanged != null) {
                if(propertyName != nameof(HasChanges)) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(HasChanges)));
            }
        }

        #endregion
    }
}
