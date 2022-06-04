namespace EasyToEnter.ASP.Tools
{
    public class HelperAttribute
    {
        public static TValue? GetValue<TAttribute, TValue>(Action? action, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute => 
            action?.Method
            .GetCustomAttributes(typeof(TAttribute), true)
            .FirstOrDefault() is TAttribute attr ? valueSelector(attr) : default;
    }
}