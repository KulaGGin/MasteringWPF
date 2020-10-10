using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;



namespace Kulagin.MasteringWPF.ViewModels {
    public class ProductNotifyViewModelExtended : BaseViewModel {
        private ProductsNotifyExtended products =  new ProductsNotifyExtended();

        public ProductNotifyViewModelExtended() {
            Products.Add(new ProductNotifyExtended() {
                                                         Id = Guid.NewGuid(),
                                                         Name = "Virtual Reality Headset",
                                                         Price = 14.99m
                                                     });

            Products.Add(new ProductNotifyExtended() {
                                                         Id = Guid.NewGuid(),
                                                         Name = "super virtual reality headset",
                                                         Price = 49.99m
                                                     });

            Products.CurrentItem = Products.Last();
            Products.CurrentItem.Validate(nameof(Products.CurrentItem.Name));
            Products.CurrentItem.Validate(nameof(Products.CurrentItem.Price));
        }

        public ProductsNotifyExtended Products {
            get { return products; }
            set {
                if(products != value) {
                    products = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}