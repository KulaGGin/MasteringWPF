using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.ViewModels {
    public class VisuallyAppealingViewModel : BaseViewModel {
        /// <summary>
        /// Gets or sets the value of the fictional number of support tickets that have come in.
        /// </summary>
        public int InCount { get; set; } = 148;

        /// <summary>
        /// Gets or sets the value of the fictional number of support tickets that have been dealt with, or gone out.
        /// </summary>
        public int OutCount { get; set; } = 112;
    }
}
