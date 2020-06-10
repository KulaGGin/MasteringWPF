using Kulagin.Mastering_WPF.Extensions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

[assembly: XmlnsDefinition("Kulagin/MasteringWPF/DataModels", "Kulagin.Mastering_WPF.DataModels")]
namespace Kulagin.Mastering_WPF.DataModels {
    public abstract class BaseDataModel : INotifyPropertyChanged {
        protected BaseDataModel() {
        }

        public abstract override string ToString();

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(params string[] propertyNames) {
            if (PropertyChanged != null) propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}