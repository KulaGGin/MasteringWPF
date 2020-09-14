using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.CustomControls.Enums {
    /// <summary>
    /// Represents the types of movement effects available in the CompanyName.ApplicationName.CustomControls.GlowButton class.
    /// </summary>
    public enum GlowMode {
        /// <summary>
        /// Represents a movement effect where the center of the gradient will not move with the mouse when it is over the control.
        /// </summary>
        NoCenterMovement,
        /// <summary>
        /// Represents a movement effect where the center of the gradient will move horiontally with the mouse when it is over the control.
        /// </summary>
        HorizontalCenterMovement,
        /// <summary>
        /// Represents a movement effect where the center of the gradient will move both horiontally and vertically with the mouse when it is over the control.
        /// </summary>
        FullCenterMovement
    }
}
