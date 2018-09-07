namespace Vuighe.Common.Extensions
{
    public static class CommonExtensions
    {
        public static string ToCamelCasing(this string str)
        {
            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}