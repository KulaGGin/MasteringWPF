using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.Extensions {
    public static class General {
        public static string GetDescription(this Enum value) {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if(fieldInfo == null)
                return Enum.GetName(value.GetType(), value);

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(attributes != null && attributes.Length > 0)
                return attributes[0].Description;

            return Enum.GetName(value.GetType(), value);
        }

        /// <summary>
        /// Returns a generic ICollection containing an item for each member of the type of enum specified by the generic T type parameter. This method will throw an ArgumentException if the provided generic T type parameter is not an enum.
        /// </summary>
        /// <typeparam name="T">The type of enum to fill the collection with.</typeparam>
        /// <param name="collection">The this ICollection.</param>
        /// <exception cref="ArgumentException" />
        public static void FillWithMembers<T>(this ICollection<T> collection) {
            if(typeof(T).BaseType != typeof(Enum)) throw new ArgumentException("The FillWithMembers<T> method can only be called with an enum as the generic type.");
            collection.Clear();
            foreach(string name in Enum.GetNames(typeof(T))) {
                collection.Add((T)Enum.Parse(typeof(T), name));
            }
        }

        /// <summary>
        /// Adds the items from the collection specified by the range input parameter into this collection.
        /// </summary>
        /// <typeparam name="T">The type of items inside the collections.</typeparam>
        /// <param name="collection">This collection.</param>
        /// <param name="range">The collection containing the items to add to this collection.</param>
        public static void AddRange<T>(this ICollection<T> collection, ICollection<T> range) {
            foreach(T item in range) collection.Add(item);
        }

        /// <summary>
        /// Appends the text input parameter to the end of the StringBuilder text if it does not already contain it.
        /// </summary>
        /// <param name="stringBuilder">The this StringBuilder.</param>
        /// <param name="text">The text to append to the StringBuilder object if it is unique.</param>
        public static void AppendUniqueOnNewLineIfNotEmpty(this StringBuilder stringBuilder, string text) {
            if(text.Trim().Length > 0 && !stringBuilder.ToString().Contains(text))
                stringBuilder.AppendFormat("{0}{1}", stringBuilder.ToString().Trim().Length == 0 ? string.Empty : Environment.NewLine, text);
        }

        /// <summary>
        /// Adds the text as an item into the collection if it does not already exist in it.
        /// </summary>
        /// <param name="collection">The this collection.</param>
        /// <param name="text">The text to add as an item if it is unique.</param>
        public static void AddUniqueIfNotEmpty(this ObservableCollection<string> collection, string text) {
            if(!string.IsNullOrEmpty(text) && !collection.Contains(text)) collection.Add(text);
        }
    }
}
