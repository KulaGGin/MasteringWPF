using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.ViewModels {
    /// <summary>
    /// A View Model that is paired with the PanelView class, which provides the data to recreate the various panel-related examples from the book.
    /// </summary>
    public class RightControlsViewModel : BitRateViewModel {
        private List<int> days = Enumerable.Range(1, 31).ToList();
        private List<int> hours;

        public RightControlsViewModel() {
            hours = new List<int>() { 12 };
            hours.AddRange(Enumerable.Range(1, 11).ToList());
        }

        public List<int> Hours {
            get { return hours; }
            set { hours = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the collection of day numerals, to be displayed in the Uniform Grid example in the View.
        /// </summary>
        public List<int> Days {
            get { return days; }
            set { days = value; NotifyPropertyChanged(); }
        }
    }
}
