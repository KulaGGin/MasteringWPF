using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    /// Represents a chapter in the related Mastering Windows Presentation Foundation book.
    public enum Chapter {
        /// Represents chapter 1 in the related Mastering Windows Presentation Foundation demonstration application.
        [Description("A Smarter Way of Working with WPF")]
        One = 1,
        /// Represents chapter 2 in the related Mastering Windows Presentation Foundation demonstration application.
        [Description("Debugging WPF Applications")]
        Two = 2,
        /// Represents chapter 3 in the related Mastering Windows Presentation Foundation demonstration application.
        [Description("Writing Custom Application Frameworks")]
        Three = 3,
        /// Represents chapter 4 in the related Mastering Windows Presentation Foundation demonstration application.
        [Description("Becoming Proficient with Data Binding")]
        Four = 4,
    }
}
