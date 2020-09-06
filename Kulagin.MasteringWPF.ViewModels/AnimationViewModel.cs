using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.ViewModels {
    public class AnimationViewModel : BaseViewModel {
        private string name = string.Empty;
        private bool isValid = false;

        /// <summary>
        /// Gets or sets the text to be used in the Validation example in the View.
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if(name != value) {
                    name = value;
                    NotifyPropertyChanged();
                    IsValid = name.Length > 2;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Boolean flag to be used in the Validation example in the View.
        /// </summary>
        public bool IsValid {
            get { return isValid; }
            set { if(isValid != value) { isValid = value; NotifyPropertyChanged(); } }
        }
    }
}
