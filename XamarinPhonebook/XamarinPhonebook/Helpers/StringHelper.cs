using System.Collections.Generic;
using System.Linq;

namespace XamarinPhonebook.Helpers
{
    public static class StringHelper
    {
        public static bool ContainsIgnoreCasing(this string str, string search)
        {
            return str.ToUpperInvariant().Contains(search.ToUpperInvariant());
        }
    }
}