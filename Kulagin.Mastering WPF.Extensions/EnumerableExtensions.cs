using System;
using System.Collections.Generic;


namespace Kulagin.Mastering_WPF.Extensions {
    public static class EnumerableExtensions {

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection) {
                action(item);
            }
        }

        public static void FillWithMembers<T>(this ICollection<T> collection) {
            if (typeof(T).BaseType != typeof(Enum)) {
                throw new ArgumentException("The FillWithMembers<T> method can only be called with an enum as the generic type.");
            }

            collection.Clear();

            foreach (string name in Enum.GetNames(typeof(T))) {
                collection.Add((T)Enum.Parse(typeof(T), name));
            }
        }
    }
}