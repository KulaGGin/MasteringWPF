using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Kulagin.MasteringWPF.DataModels.Attributes {
    public class MinimumAttribute : ValidationAttribute {
        private double minimumValue = 0.0;

        public MinimumAttribute(double minimumValue) {
            this.minimumValue = minimumValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if ((value.GetType() != typeof(decimal) || (decimal)value < (decimal)minimumValue)) {
                string[] memberNames = new string[] {validationContext.MemberName};

                return new ValidationResult(ErrorMessage, memberNames);
            }

            return ValidationResult.Success;
        }
    }
}