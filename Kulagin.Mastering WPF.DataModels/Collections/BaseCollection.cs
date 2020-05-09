using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Kulagin.Mastering_WPF.Extensions;


namespace Kulagin.Mastering_WPF.DataModels.Collections {

    public class BaseCollection<T> : ObservableCollection<T>, INotifyPropertyChanged where T : class, INotifyPropertyChanged, new() {

        protected T currentItem;


        public BaseCollection(IEnumerable<T> collection) : this() {
            foreach (T item in collection) {
                Add(item);
            }
        }


        public BaseCollection(params T[] collection) : this(collection as IEnumerable<T>) {
        }


        public BaseCollection() : base() {
            currentItem = new T();
        }


        public virtual T CurrentItem {
            get { return currentItem; }
            set {
                T oldCurrentItem = currentItem;
                currentItem = value;
                CurrentItemChanged?.Invoke(oldCurrentItem, currentItem);
                NotifyPropertyChanged();
            }
        }


        public bool IsEmpty { get { return !this.Any(); } }

        public delegate void ItemPropertyChanged(T item, string propertyName);

        public virtual ItemPropertyChanged CurrentItemPropertyChanged { get; set; }

        public delegate void CurrentItemChange(T oldItem, T newItem);

        public virtual CurrentItemChange CurrentItemChanged { get; set; }


        public T GetNewItem() {
            return new T();
        }


        public virtual void AddEmptyItem() {
            Add(new T());
        }


        public virtual void Add(IEnumerable<T> collection) {
            collection.ForEach(i => base.Add(i));
        }


        public virtual void Add(params T[] items) {
            if (items.Length == 1) base.Add(items[0]);
            else Add(items as IEnumerable<T>);
        }


        protected override void InsertItem(int index, T item) {
            if (item != null) {
                item.PropertyChanged += Item_PropertyChanged;
                base.InsertItem(index, item);
                if (Count == 1) CurrentItem = item;
            }
        }


        protected override void SetItem(int index, T item) {
            if (item != null) {
                item.PropertyChanged += Item_PropertyChanged;
                base.SetItem(index, item);
                if (Count == 1) CurrentItem = item;
            }
        }


        protected override void ClearItems() {
            foreach (T item in this) {
                item.PropertyChanged -= Item_PropertyChanged;
            }

            base.ClearItems();
        }


        protected override void RemoveItem(int index) {
            T item = this[index];
            if (item != null) item.PropertyChanged -= Item_PropertyChanged;
            base.RemoveItem(index);
        }


        public void ResetCurrentItemPosition() {
            if (this.Any()) CurrentItem = this.First();
        }


        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (sender as T == CurrentItem) CurrentItemPropertyChanged?.Invoke(currentItem, e.PropertyName);
            NotifyPropertyChanged(e.PropertyName);
        }


        #region INotifyPropertyChanged Members

        protected override event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChanged(params string[] propertyNames) {
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