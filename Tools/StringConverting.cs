using System.Globalization;

namespace EasyToEnter.ASP.Tools
{
    public static class StringConverting
    {
        public static string IntToString(int value) => value.ToString("N0", CultureInfo.InvariantCulture).Replace(',', ' ');

        public static string IntToString(int? value) => value != null ? IntToString((int)value) : string.Empty;
    }
}