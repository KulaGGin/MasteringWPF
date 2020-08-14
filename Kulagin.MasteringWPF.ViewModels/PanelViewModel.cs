using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.ViewModels {
    /// <summary>
    /// A View Model that is paired with the PanelView class, which provides the data to recreate the various panel-related examples from the book.
    /// </summary>
    public class PanelViewModel : BitRateViewModel {
        private List<int> days = Enumerable.Range(1, 31).ToList();

        /// <summary>
        /// Gets or sets the collection of day numerals, to be displayed in the Uniform Grid example in the View.
        /// </summary>
        public List<int> Days {
            get { return days; }
            set { days = value; NotifyPropertyChanged(); }
        }
    }
}
