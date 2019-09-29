using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorConsole.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ReadOnlyCollection<T> collection)
        {
            return collection is null || !collection.Any();
        }

        public static bool IsNullOrEmpty(this Array array)
        {
            return array is null || array.Length == 0;
        }
    }
}
