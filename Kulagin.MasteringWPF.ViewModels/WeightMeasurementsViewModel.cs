using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.ViewModels {
    public class WeightMeasurementsViewModel : BaseViewModel {
        private List<int> weights = new List<int>() { 90, 89, 92, 91, 94, 95, 98, 99, 101 };
        public List<int> Weights {
            get { return weights; }
            set { weights = value; NotifyPropertyChanged(); }
        }
    }
}
