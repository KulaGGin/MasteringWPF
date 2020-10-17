using System;
using System.Collections;
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

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) {
            HashSet<TKey> keys = new HashSet<TKey>();
            foreach(TSource element in source) {
                if(keys.Add(keySelector(element))) {
                    yield return element;
                }
            }
        }

        public static int Count(this IEnumerable collection) {
            int count = 0;
            foreach(object item in collection) count++;
            return count;
        }

        public static string ToCommaSeparatedString<T>(this IEnumerable<T> collection) {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 0;
            foreach(T item in collection) {
                if(index > 0) {
                    if(index < collection.Count() - 1)
                        stringBuilder.Append(", ");
                    else if(index == collection.Count() - 1)
                        stringBuilder.Append(" and ");
                }
                stringBuilder.Append(item.ToString());
                index++;
            }
            return stringBuilder.ToString();
        }
    }
}
