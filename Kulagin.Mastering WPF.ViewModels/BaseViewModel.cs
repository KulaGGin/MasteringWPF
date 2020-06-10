using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace Kulagin.Mastering_WPF.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {

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