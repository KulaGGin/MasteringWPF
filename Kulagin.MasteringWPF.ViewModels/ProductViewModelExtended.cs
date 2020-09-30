using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;


namespace Kulagin.MasteringWPF.ViewModels {
    public class ProductViewModelExtended : BaseViewModel {
        private ProductsExtended products = new ProductsExtended();

        public ProductViewModelExtended() {
            Products.Add(new ProductExtended() {
                                                   Id = Guid.NewGuid(),
                                                   Name = "Virtual Reality Headset",
                                                   Price = 14.99m
                                               });

            Products.Add(new ProductExtended() {
                                                   Id = Guid.NewGuid(),
                                                   Name = "Virtual Reality Headset"
                                               });

            Products.CurrentItemChanged += Products_CurrentItemChanged;
            Products.CurrentItem = Products.Last();
            ValidateUniqueName(Products.CurrentItem);
        }

        public ProductsExtended Products {
            get { return products; }
            set {
                if (products != value) {
                    products = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void Products_CurrentItemChanged(
            ProductExtended oldProduct, ProductExtended newProduct) {
            if (newProduct != null)
                newProduct.PropertyChanged += Product_PropertyChanged;

            if (oldProduct != null)
                oldProduct.PropertyChanged -= Product_PropertyChanged;
        }

        private void Product_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == nameof(Products.CurrentItem.Name))
                ValidateUniqueName(Products.CurrentItem);
        }

        private void ValidateUniqueName(ProductExtended product) {
            string errorMessage = "The product name must be unique.";
            if (!IsProductNameUnique(product))
                product.ExternalErrors.Add(errorMessage);
            else
                product.ExternalErrors.Remove(errorMessage);
        }

        private bool IsProductNameUnique(ProductExtended product) =>
            !Products.Any(p => p.Id != product.Id &&
                               !string.IsNullOrEmpty(p.Name) && p.Name == product.Name);
    }
}