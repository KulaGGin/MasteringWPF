using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.ViewModels {
    public class BitRateViewModel : BaseViewModel {
        private ObservableCollection<BitRate> bitRates = new ObservableCollection<BitRate>();
        private BitRate bitRate = BitRate.Sixteen;

        public BitRateViewModel() {
            bitRates.FillWithMembers();
        }
        public ObservableCollection<BitRate> BitRates {
            get { return bitRates; }
            set {
                if(bitRates != value) {
                    bitRates = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public BitRate BitRate {
            get { return bitRate; }
            set {
                if(bitRate != value) {
                    bitRate = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
