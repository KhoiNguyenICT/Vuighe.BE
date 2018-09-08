using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Vuighe.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToTsQueryCompat(this string source)
        {
            var space = new Regex(@"\s+");
            return $"{space.Replace(source.Trim().RemoveAccent(), "&")}:*";
        }

        public static string RemoveAccent(this string value)
        {
            if (String.IsNullOrEmpty(value)) return value;
            return String.Concat(value.Normalize(NormalizationForm.FormD).Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)).Normalize(NormalizationForm.FormC);
        }
    }
}