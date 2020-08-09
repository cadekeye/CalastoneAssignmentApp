
namespace CalastoneLibrary
{
    public static class CalastoneExtensions
    {
        public static string FormatString(this string content)
        {
            content = content.Replace(".", ". ")
             .Replace(",", ", ")
             .Replace(";", "; ");

            return content;
        }
    }
}
