using System.Globalization;
using static EasyToEnter.ASP.Tools.LoremIpsum;

namespace EasyToEnter.ASP.Tools
{
    public static class StringConverting
    {
        public static string IntToString(int value) => value.ToString("N0", CultureInfo.InvariantCulture).Replace(',', ' ');

        public static string IntToString(int? value) => value != null ? IntToString((int)value) : string.Empty;

        public static string StringArrayToString(string[] stringArray, string separator) => string.Join(separator, stringArray);

        public static string StringPhoneNumberToString(string phoneNumber)
        {
            try
            {
                return string.Format("{0:+# (###) ###-##-##}", Convert.ToInt64(phoneNumber));
            }
            catch
            {
                return phoneNumber;
            }
        }
    }
}