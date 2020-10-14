using System;
using System.ComponentModel;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.DataModels.Interfaces;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.DataModels {
    public class Feedback : IAnimatable, INotifyPropertyChanged {
        private string message = string.Empty;
        private FeedbackType type = FeedbackType.None;
        private TimeSpan duration = new TimeSpan(0, 0, 4);
        private bool isPermanent = false;
        private Animatable animatable;

        public Feedback(string message, FeedbackType type, TimeSpan duration) {
            Message = message;
            Type = type;
            Duration = duration == TimeSpan.Zero ? this.duration : duration;
            IsPermanent = false;
            Animatable = new Animatable(this);
        }

        public Feedback(string message, bool isSuccess, bool isPermanent) : this(message, isSuccess ? FeedbackType.Success : FeedbackType.Error, TimeSpan.Zero) {
            IsPermanent = isPermanent;
        }

        public Feedback(string message, FeedbackType type) : this(message, type, TimeSpan.Zero) {
        }

        public Feedback(string message, bool isSuccess) : this(message, isSuccess ? FeedbackType.Success : FeedbackType.Error, TimeSpan.Zero) {
        }

        public Feedback() : this(string.Empty, FeedbackType.None) {
        }

        public string Message {
            get { return message; }
            set {
                message = value;
                NotifyPropertyChanged();
            }
        }

        public TimeSpan Duration {
            get { return duration; }
            set {
                duration = value;
                NotifyPropertyChanged();
            }
        }

        public FeedbackType Type {
            get { return type; }
            set {
                type = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsPermanent {
            get { return isPermanent; }
            set {
                isPermanent = value;
                NotifyPropertyChanged();
            }
        }

        #region IAnimatable Members

        public Animatable Animatable { get { return animatable; } set { animatable = value; } }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(params string[] propertyNames) {
            if (PropertyChanged != null) {
                propertyNames.ForEach(p => PropertyChanged(this, new PropertyChangedEventArgs(p)));
                PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
            }
        }

        #endregion
    }
}