using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kulagin.MasteringWPF.Views.Controls {
    /// <summary>
    /// Interaction logic for BoundlessTextBlock.xaml
    /// </summary>
    public partial class BoundlessTextBlock : TextBlock {
        public BoundlessTextBlock() {
            InitializeComponent();
        }

        #region Overrides of FrameworkElement

        protected override Geometry GetLayoutClip(Size layoutSlotSize) {
            return null;
        }

        #endregion

    }
}
