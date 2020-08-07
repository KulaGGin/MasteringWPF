using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    /// <summary>
    /// Specifies the buttons that are displayed on a message box.
    /// </summary>
    public enum MessageBoxButton {
        /// <summary>
        /// The message box displays an OK button.
        /// </summary>
        Ok = 0,
        /// <summary>
        /// The message box displays OK and Cancel buttons.
        /// </summary>
        OkCancel = 1,
        /// <summary>
        /// The message box displays Yes, No, and Cancel buttons.
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// The message box displays Yes and No buttons.
        /// </summary>
        YesNo = 4,
    }
}
