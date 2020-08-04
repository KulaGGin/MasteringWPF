using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace Kulagin.MasteringWPF.Converters {

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public abstract class BaseVisibilityConverter {

        protected Visibility FalseVisibilityValue { get; set; } = Visibility.Collapsed;

        public enum FalseVisibility {
            Hidden,
            Collapsed
        }

        public FalseVisibility FalseVisibilityState {
            get { return FalseVisibilityValue == Visibility.Collapsed ? FalseVisibility.Collapsed : FalseVisibility.Hidden; }
            set { FalseVisibilityValue = value == FalseVisibility.Collapsed ? Visibility.Collapsed : Visibility.Hidden; }
        }

        public bool IsInverted { get; set; }
    }
}
