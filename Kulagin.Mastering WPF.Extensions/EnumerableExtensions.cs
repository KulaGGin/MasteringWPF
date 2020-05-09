using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.Mastering_WPF.Extensions {
    public static class EnumerableExtensions {

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach(T item in collection) action(item);
        }

    }
}
