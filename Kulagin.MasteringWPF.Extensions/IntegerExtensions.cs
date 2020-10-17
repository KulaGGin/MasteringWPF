using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.Extensions {
    public static class IntegerExtensions {
        public static string Pluralize(this int input, string wordToAdjust) {
            return $"{wordToAdjust}{(input == 1 ? string.Empty : "s")}";
        }

        public static string Combine(this int input, string wordToAdjust) {
            return $"{input} {wordToAdjust}{(input == 1 ? string.Empty : "s")}";
        }
    }
}
