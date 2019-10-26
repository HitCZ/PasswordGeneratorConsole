using PasswordGeneratorConsole.Extensions;
using System.Collections.Generic;

namespace PasswordGeneratorConsole.Infrastructure.Comparers
{
    public class StringEqualityComparer : IEqualityComparer<string>
    {
        private readonly bool isCaseSensitive;

        public StringEqualityComparer(bool isCaseSensitive = true)
        {
            this.isCaseSensitive = isCaseSensitive;
        }

        public bool Equals(string x, string y)
        {
            if (x.IsNullOrEmpty() ^ y.IsNullOrEmpty())
                return false;
            if (x.IsNullOrEmpty() && y.IsNullOrEmpty())
                return true;
            return !isCaseSensitive ? x.ToLower().Equals(y.ToLower()) : x.Equals(y);
        }

        public int GetHashCode(string obj) => 0;
    }
}
