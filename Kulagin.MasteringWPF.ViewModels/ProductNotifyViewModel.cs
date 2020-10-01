using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;


namespace Kulagin.MasteringWPF.ViewModels {
    public class ProductNotifyViewModel : BaseViewModel {
        private ProductsNotify products = new ProductsNotify();
        public ProductNotifyViewModel() {
            Products.Add(new ProductNotify() {
                                                 Id = Guid.NewGuid(),
                                                 Name = "Virtual Reality Headset",
                                                 Price = 14.99m
                                             });
            Products.Add(new ProductNotify() {
                                                 Id = Guid.NewGuid(),
                                                 Name = "Virtual Reality Headset"
                                             });
            Products.CurrentItem = Products.Last();
            Products.CurrentItem.Validate(nameof(Products.CurrentItem.Name));
            Products.CurrentItem.Validate(nameof(Products.CurrentItem.Price));
        }
        public ProductsNotify Products {
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
