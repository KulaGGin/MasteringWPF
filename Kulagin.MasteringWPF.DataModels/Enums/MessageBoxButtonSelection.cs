using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    /// <summary>
    /// Specifies which message box button that a user clicks.
    /// </summary>
    public enum MessageBoxButtonSelection {
        /// <summary>
        /// The message box returns no result.
        /// </summary>
        None,
        /// <summary>
        /// The result value of the message box is OK.
        /// </summary>
        Ok,
        /// <summary>
        /// The result value of the message box is Cancel.
        /// </summary>
        Cancel,
        /// <summary>
        /// The result value of the message box is Yes.
        /// </summary>
        Yes,
        /// <summary>
        /// The result value of the message box is No.
        /// </summary>
        No,
    }
}
