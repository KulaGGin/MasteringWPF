using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Kulagin.Mastering_WPF.DataModels.Collections;
using Kulagin.Mastering_WPF.DataModels.Interfaces;
using Kulagin.Mastering_WPF.Extensions;


namespace CompanyName.ApplicationName.DataModels.Collections {
    public class BaseSynchronizableCollection<T> : BaseCollection<T> where T : class, ISynchronizableDataModel<T>, INotifyPropertyChanged, new() {

        
        public BaseSynchronizableCollection(IEnumerable<T> collection) : base(collection) {
        }

        public BaseSynchronizableCollection(params T[] collection) : base(collection as IEnumerable<T>) {
        }


        public BaseSynchronizableCollection() : base() {
        }


        public virtual bool HasChanges { get { return this.Any(i => i.HasChanges); } }


        public virtual bool AreSynchronized { get { return this.All(i => i.IsSynchronized); } }

        
        public virtual IEnumerable<T> ChangedCollection { get { return this.Where(i => i.HasChanges); } }


        public virtual void Synchronize() {
            this.ForEach(i => i.Synchronize());
        }


        public virtual void RevertState() {
            this.ForEach(i => i.RevertState());
        }
    }
}