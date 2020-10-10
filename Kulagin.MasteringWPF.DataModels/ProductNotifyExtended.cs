﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Attributes;
using Kulagin.MasteringWPF.DataModels.Enums;


namespace Kulagin.MasteringWPF.DataModels {
    public class ProductNotifyExtended : BaseNotifyValidationModelExtended {
        private Guid id = Guid.Empty;
        private string name = string.Empty;
        private decimal price = 0;

        /// <summary>
        /// Gets or sets the unique identification number of the ProductNotify object.
        /// </summary>
        public Guid Id {
            get { return id; }
            set { if(id != value) { id = value; NotifyPropertyChanged(); } }
        }

        /// <summary>
        /// Gets or sets the name of the ProductNotify object.
        /// </summary>
        //[Required(ErrorMessage = "Please enter the product name.")]
        //[MaxLength(25, ErrorMessage = "The product name cannot be longer than twenty-five characters.")]
        public string Name {
            get { return name; }
            set { if(name != value) { name = value; NotifyPropertyChangedAndValidate(); } }
        }

        /// <summary>
        /// Gets or sets the price of the ProductNotify object.
        /// </summary>
        //[Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Please enter a valid price for the product.")]
        [Minimum(0.01, ErrorMessage = "Please enter a valid price for the product.")]
        public decimal Price {
            get { return price; }
            set { if(price != value) { price = value; NotifyPropertyChangedAndValidate(); } }
        }

        /// <summary>
        /// Gets the validation message relating to the propertyName input parameter, if there are any validation errors.
        /// </summary>
        public override IEnumerable<string> this[string propertyName] {
            get {
                List<string> errors = new List<string>();
                if(propertyName == nameof(Name)) {
                    if(string.IsNullOrEmpty(Name)) errors.Add("Please enter the product name.");
                    else if(Name.Length > 25) errors.Add("The product name cannot be longer than twenty-five characters.");
                    if(Name.Length > 0 && char.IsLower(Name[0])) errors.Add("The first letter of the product name must be a capital letter.");
                }
                else if(propertyName == nameof(Price) && ValidationLevel == ValidationLevel.Full && Price == 0) errors.Add("Please enter a valid price for the product.");
                return errors;
            }
        }

        public override void ValidateAllProperties() {
            Validate(nameof(Name), nameof(Price));
        }
    }
}
