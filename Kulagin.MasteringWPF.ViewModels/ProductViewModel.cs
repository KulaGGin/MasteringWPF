using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.ViewModels {
    public class ProductViewModel : BaseViewModel {
        private Product product = new Product();
        public Product Product {
            get { return product; }
            set {
                if(product != value) {
                    product = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
