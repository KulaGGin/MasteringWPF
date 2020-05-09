using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.Mastering_WPF.DataModels.Interfaces;


namespace Kulagin.Mastering_WPF.DataModels {
    public abstract class BaseSynchronizableDataModel<T> : BaseDataModel where T : BaseDataModel, ISynchronizableDataModel<T>, new() {
        private T originalState;
        public T OriginalState {
            get { return originalState; }
            private set { originalState = value; }
        }

        public abstract bool PropertiesEqual(T dataModel);

        public bool HasChanges {
            get { return originalState != null && !PropertiesEqual(originalState); }
        }
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

        public abstract void CopyValuesFrom(T dataModel);

        public virtual T Clone() {
            T clone = new T();
            clone.CopyValuesFrom(this as T);
            return clone;
        }
    }
}
