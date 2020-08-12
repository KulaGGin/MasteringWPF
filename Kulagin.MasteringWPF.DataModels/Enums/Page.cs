using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    /// <summary>
    /// Represents a page or View in the related Mastering Windows Presentaion Foundation demonstration application.
    /// </summary>
    public enum Page {

        /// <summary>
        /// Represents the Bit Rate page in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Bit Rate")]
        BitRate,

        /// <summary>
        /// Represents the Weight Measurement page in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Weight Measurement")]
        WeightMeasurements,

        /// <summary>
        /// Represents the User page in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("User")]
        User,
    }
}
