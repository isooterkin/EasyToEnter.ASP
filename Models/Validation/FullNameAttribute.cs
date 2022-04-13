using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EasyToEnter.ASP.Models.Validation
{
    public class FullNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string code) return false;

            Regex regex = new(@"^[А-ЯЁ][а-яё]*$");

            return regex.IsMatch(code);
        }
    }
}
