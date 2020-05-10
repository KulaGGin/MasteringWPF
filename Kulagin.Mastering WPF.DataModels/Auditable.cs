using System;


namespace Kulagin.Mastering_WPF.DataModels {

    public class Auditable : BaseDataModel {
        private DateTime createdOn;
        private DateTime? updatedOn;
        private User createdBy, updatedBy;


        public Auditable(DateTime createdOn, User createdBy, DateTime? updatedOn, User updatedBy) {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
        }


        public Auditable(User createdBy) : this(DateTime.Now, createdBy, null, new User()) {
        }


        public Auditable() {
        }


        public DateTime CreatedOn {
            get { return createdOn; }
            set {
                createdOn = value;
                NotifyPropertyChanged();
            }
        }

        public User CreatedBy {
            get { return createdBy; }
            set {
                createdBy = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? UpdatedOn {
            get { return updatedOn; }
            set {
                updatedOn = value;
                NotifyPropertyChanged();
            }
        }

        public User UpdatedBy {
            get { return updatedBy; }
            set {
                updatedBy = value;
                NotifyPropertyChanged();
            }
        }


        public override string ToString() {
            return UpdatedOn.HasValue
                       ? $"Created on {CreatedOn.ToLongDateString()} by {CreatedBy.Name}, last updated on {UpdatedOn.Value.ToLongDateString()} by {UpdatedBy.Name}"
                       : $"Created on {CreatedOn.ToLongDateString()} by {CreatedBy.Name}";
        }
    }
}