using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.Mastering_WPF.Extensions {
    /// <summary>
    /// Provides a variety of commonly used methods that extend the functionality of the .NET Framework classes.
    /// </summary>
    public static class General {
        /// <summary>
        /// Returns the content of the System.ComponentModel.DescriptionAttribute that relates to this enum if one is set, or the name of the enum otherwise.
        /// </summary>
        /// <param name="value">The this enum.</param>
        /// <returns>The content of the System.ComponentModel.DescriptionAttribute that relates to this enum if one is set, or the name of the enum otherwise.</returns>
        public static string GetDescription(this Enum value) {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if(fieldInfo == null) {
                return Enum.GetName(value.GetType(), value);
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(attributes != null && attributes.Length > 0) {
                return attributes[0].Description;
            }

            return Enum.GetName(value.GetType(), value);
        }
    }
}
