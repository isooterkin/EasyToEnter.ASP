namespace EasyToEnter.ASP.Tools
{
    public static class StringConverting
    {
        public static string IntToString(int value) => value > 99 ? value.ToString("0,0") : value.ToString();
    }
}