using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PasswordGeneratorConsole.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ReadOnlyCollection<T> collection)
        {
            return collection is null || !collection.Any();
        }

        public static bool IsNullOrEmpty(this Array array) => array is null || array.Length == 0;

        public static bool IsNullOrEmpty<T>(this List<T> list) => list is null || !list.Any();

        public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary is null || !dictionary.Any();
        }
    }
}
