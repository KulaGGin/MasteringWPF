using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kulagin.MasteringWPF.DataModels.Collections {
    public class FeedbackCollection : BaseAnimatableCollection<Feedback> {
        public FeedbackCollection(IEnumerable<Feedback> feedbackCollection) :
            base(feedbackCollection) {
        }

        public FeedbackCollection() : base() {
        }

        public new void Add(Feedback feedback) {
            if (!string.IsNullOrEmpty(feedback.Message)
                && (Count == 0 || this.All(f => f.Message != feedback.Message)))
                base.Add(feedback);
        }

        public void Add(string message, bool isSuccess) {
            Add(new Feedback(message, isSuccess));
        }
    }
}