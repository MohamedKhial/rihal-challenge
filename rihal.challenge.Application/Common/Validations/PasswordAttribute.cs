using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace rihal.challenge.Application.Common.Validations
{
    public class PasswordAttribute : ValidationAttribute
    {
        public PasswordAttribute() : base()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return ValidationResult.Success;
            }

            int valueLength = value.ToString().Length;
            if (valueLength < 8 || valueLength > 20)
            {
                return new ValidationResult("PasswordRequiredLength");
            }

            bool isContainDigit = new Regex(@"^(.*\d.*)$").IsMatch(value.ToString());
            if (isContainDigit == false)
            {
                return new ValidationResult("PasswordPattern");
            }

            bool isContainLetter = new Regex(@"^(.*\p{L}.*)$").IsMatch(value.ToString());
            if (isContainLetter == false)
            {
                return new ValidationResult("PasswordPattern");
            }

            return ValidationResult.Success;
        }
    }
}
