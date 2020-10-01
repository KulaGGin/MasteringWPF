using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class BaseNotifyValidationModel : INotifyPropertyChanged, INotifyDataErrorInfo {
        protected Dictionary<string, List<string>> AllPropertyErrors { get; } =
            new Dictionary<string, List<string>>();

        public ObservableCollection<string> Errors =>
            new ObservableCollection<string>(AllPropertyErrors.Values.SelectMany(e => e).Distinct());

        public abstract IEnumerable<string> this[string propertyName] { get; }

        public void NotifyPropertyChangedAndValidate(
            params string[] propertyNames) {
            foreach (string propertyName in propertyNames)
                NotifyPropertyChangedAndValidate(propertyName);
        }

        public void NotifyPropertyChangedAndValidate(
            [CallerMemberName] string propertyName = "") {
            NotifyPropertyChanged(propertyName);
            Validate(propertyName);
        }

        public void Validate(string propertyName) {
            UpdateErrors(propertyName, this[propertyName]);
        }

        private void UpdateErrors(string propertyName,
                                  IEnumerable<string> errors) {
            if (errors.Any()) {
                if (AllPropertyErrors.ContainsKey(propertyName))
                    AllPropertyErrors[propertyName].Clear();
                else
                    AllPropertyErrors.Add(propertyName, new List<string>());

                AllPropertyErrors[propertyName].AddRange(errors);

                OnErrorsChanged(propertyName);
            }
            else {
                if (AllPropertyErrors.ContainsKey(propertyName))
                    AllPropertyErrors.Remove(propertyName);

                OnErrorsChanged(propertyName);
            }
        }

        #region INotifyDataErrorInfo Members

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnErrorsChanged(string propertyName) {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            NotifyPropertyChanged(nameof(Errors), nameof(HasErrors));
        }

        public IEnumerable GetErrors(string propertyName) {
            List<string> propertyErrors = new List<string>();
            if (string.IsNullOrEmpty(propertyName))
                return propertyErrors;

            AllPropertyErrors.TryGetValue(propertyName, out propertyErrors);
            return propertyErrors;
        }

        public bool HasErrors => AllPropertyErrors.Any(p => p.Value != null && p.Value.Any());

        #endregion

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(
            params string[] propertyNames) {
            if (PropertyChanged != null)
                propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged(
            [CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}