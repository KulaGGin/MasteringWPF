using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;
using Kulagin.MasteringWPF.DataModels.Interfaces;
using Kulagin.MasteringWPF.Managers;


namespace Kulagin.MasteringWPF.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {

        private bool isFocused = false;

        public T AddNewDataTypeToCollection<S, T>(S collection)
            where S : BaseSynchronizableCollection<T>
            where T : BaseSynchronizableDataModel<T>, new() {
            T item = collection.GetNewItem();
            if(item is IAuditable)
                ((IAuditable)item).Auditable.CreatedOn = DateTime.Now;
            item.Synchronize();
            collection.Add(item);
            collection.CurrentItem = item;
            return item;
        }

        public T InsertNewDataTypeToCollection<S, T>(int index, S collection)
            where S : BaseSynchronizableCollection<T>
            where T : BaseSynchronizableDataModel<T>, new() {
            T item = collection.GetNewItem();
            if(item is IAuditable)
                ((IAuditable)item).Auditable.CreatedOn = DateTime.Now;
            item.Synchronize();
            collection.Insert(index, item);
            collection.CurrentItem = item;
            return item;
        }
        public void RemoveDataTypeFromCollection<S, T>(S collection, T item)
            where S : BaseSynchronizableCollection<T>
            where T : BaseSynchronizableDataModel<T>, new() {
            int index = collection.IndexOf(item);
            collection.RemoveAt(index);
            if(index > collection.Count) index = collection.Count;
            else if(index < 0) index++;
            if(index > 0 && index < collection.Count &&
               collection.CurrentItem != collection[index])
                collection.CurrentItem = collection[index];
        }

        public StateManager StateManager {
            get { return StateManager.Instance; }
        }

        public bool IsFocused {
            get { return isFocused; }
            set {
                if(isFocused != value) {
                    isFocused = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames) {
            if (PropertyChanged != null) {
                foreach (string propertyName in propertyNames) {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
