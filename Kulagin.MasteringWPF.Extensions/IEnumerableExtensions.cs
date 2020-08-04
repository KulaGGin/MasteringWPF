using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.Extensions {
    public static class IEnumerableExtensions {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach(T item in collection) {
                action(item);
            }
        }
    }
}
