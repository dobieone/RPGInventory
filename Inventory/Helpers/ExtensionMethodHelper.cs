using System.Text.RegularExpressions;

namespace MD.Helpers
{
    public static class ExtensionMethodHelper
    {
        public static string RemoveSpecialChars(this string value)
        {
            return Regex.Replace(value, @"[^0-9a-zA-Z\._]", string.Empty);
        }
    }
}
