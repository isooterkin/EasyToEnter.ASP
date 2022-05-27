namespace EasyToEnter.ASP.Tools
{
    public static class StringConverting
    {
        private static string Converting(int value) => value > 99 ? value.ToString("0,0") : value.ToString();

        public static string IntToString(int value) => Converting(value);

        public static string IntToString(int? value) => value != null ? Converting((int)value) : string.Empty;
    }
}