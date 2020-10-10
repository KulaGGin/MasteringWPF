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
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using Kulagin.MasteringWPF.DataModels.Enums;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class BaseNotifyValidationModelExtended : INotifyPropertyChanged, INotifyDataErrorInfo {
        protected Dictionary<string, List<string>> AllPropertyErrors { get; } = new Dictionary<string, List<string>>();

        public abstract IEnumerable<string> this[string propertyName] { get; }

        private ValidationLevel validationLevel = ValidationLevel.Full;

        protected BaseNotifyValidationModelExtended() {
            ExternalErrors.CollectionChanged += ExternalErrors_CollectionChanged;
        }

        public ValidationLevel ValidationLevel {
            get { return validationLevel; }
            set { if(validationLevel != value) { validationLevel = value; } }
        }

        public virtual ObservableCollection<string> Errors {
            get {
                ObservableCollection<string> errors = new ObservableCollection<string> (AllPropertyErrors.Values.SelectMany(e => e).Distinct());
                ExternalErrors.Where(e => !errors.Contains(e)).ForEach(e => errors.Add(e));
                return errors;
            }
        }

        private void ExternalErrors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            NotifyPropertyChanged(nameof(Errors), nameof(HasErrors));
        }

        public ObservableCollection<string> ExternalErrors { get; } =
            new ObservableCollection<string>();
        public abstract void ValidateAllProperties();

        public void NotifyPropertyChangedAndValidate(
            params string[] propertyNames) {
            foreach(string propertyName in propertyNames)
                NotifyPropertyChangedAndValidate(propertyName);
        }

        public void NotifyPropertyChangedAndValidate(
            [CallerMemberName] string propertyName = "") {
            NotifyPropertyChanged(propertyName);
            Validate(propertyName);
        }

        public void Validate(params string[] propertyNames) {
            foreach(string propertyName in propertyNames) Validate(propertyName);
        }

        private void UpdateErrors(string propertyName,
                                  IEnumerable<string> errors) {
            if(errors.Any()) {
                if(AllPropertyErrors.ContainsKey(propertyName))
                    AllPropertyErrors[propertyName].Clear();
                else
                    AllPropertyErrors.Add(propertyName, new List<string>());

                AllPropertyErrors[propertyName].AddRange(errors);

                OnErrorsChanged(propertyName);
            }
            else {
                if(AllPropertyErrors.ContainsKey(propertyName))
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
            if(string.IsNullOrEmpty(propertyName))
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
            if(PropertyChanged != null)
                propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
        }

        protected virtual void NotifyPropertyChanged(
            [CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
