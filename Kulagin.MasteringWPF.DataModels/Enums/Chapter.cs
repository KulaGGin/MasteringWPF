using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    /// Represents a chapter in the related Mastering Windows Presentation Foundation book.
    public enum Chapter {
        /// <summary>
        /// Represents a chapter in the related Mastering Windows Presentaion Foundation book.
        /// </summary>
        [Description("A Smarter Way of Working with WPF")]
        One = 1,
        /// <summary>
        /// Represents chapter 2 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Debugging WPF Applications")]
        Two = 2,
        /// <summary>
        /// Represents chapter 3 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Writing Custom Application Frameworks")]
        Three = 3,
        /// <summary>
        /// Represents chapter 4 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Becoming Proficient with Data Binding")]
        Four = 4,
        /// <summary>
        /// Represents chapter 5 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Using the Right Controls for the Job")]
        Five = 5,
        /// <summary>
        /// Represents chapter 6 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Adapting the Built-in Controls")]
        Six = 6,
        /// <summary>
        /// Represents chapter 8 in the related Mastering Windows Presentaion Foundation demonstration application.
        /// </summary>
        [Description("Creating Visually Appealing User Interfaces")]
        Eight = 8,
    }
}
