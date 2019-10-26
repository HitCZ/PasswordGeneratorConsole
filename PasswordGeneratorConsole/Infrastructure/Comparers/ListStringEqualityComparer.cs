using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordGeneratorConsole.Infrastructure.Comparers
{
    public class ListStringEqualityComparer : IEqualityComparer<List<string>>
    {
        #region Fields

        private readonly bool isCaseSensitive;

        #endregion Fields

        #region Constructor

        public ListStringEqualityComparer(bool caseSensitive = true)
        {
            isCaseSensitive = caseSensitive;
        }

        #endregion Constructor

        #region Public Methods

        public bool Equals(List<string> x, List<string> y)
        {
            if (x is null)
                throw new ArgumentNullException(nameof(x));
            if (y is null)
                throw new ArgumentNullException(nameof(y));

            if (x.Count != y.Count)
                return false;

            var stringComparer = isCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
            var listsAreEqual = x.All(s => y.Contains(s, stringComparer));

            return listsAreEqual;
        }

        public int GetHashCode(List<string> obj) => 0;

        #endregion Public Methods
    }
}
