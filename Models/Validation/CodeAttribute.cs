using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EasyToEnter.ASP.Validation
{
    public class CodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string code) return false;

            Regex regex = new(@"^[0-9]{2}$");

            return regex.IsMatch(code);
        }
    }
}