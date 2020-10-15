using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;


namespace Kulagin.MasteringWPF.Managers {
    public class FeedbackManager : INotifyPropertyChanged {
        private static FeedbackCollection feedback = new FeedbackCollection();
        private static FeedbackManager instance = null;

        private FeedbackManager() {
        }

        public static FeedbackManager Instance {
            get { return instance ?? (instance = new FeedbackManager()); }
        }

        public FeedbackCollection Feedback {
            get { return feedback; }
            set {
                feedback = value;
                NotifyPropertyChanged();
            }
        }

        public void Add(Feedback feedback) {
            Feedback.Add(feedback);
        }

        public void Add(string message, bool isSuccess) {
            Add(new Feedback(message, isSuccess));
        }

        public void Add<T>(DataOperationResult<T> result, bool isPermanent) {
            Add(new Feedback(result.Description, result.IsSuccess, isPermanent));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(params string[] propertyNames) {
            if (PropertyChanged != null) {
                foreach (string propertyName in propertyNames) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
