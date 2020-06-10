using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.Mastering_WPF.DataModels.Enums {
    public enum BitRate {
        [Description("16 bits")]
        Sixteen = 16,
        [Description("24 bits")]
        TwentyFour = 24,
        [Description("32 bits")]
        ThirtyTwo = 32,
    }
}
