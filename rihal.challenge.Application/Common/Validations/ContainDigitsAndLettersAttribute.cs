using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace rihal.challenge.Application.Common.Validations
{
    public class ContainDigitsAndLettersAttribute : ValidationAttribute
    {
        public ContainDigitsAndLettersAttribute()
            : base("{0} must contain at least one digit and one letter")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                bool isContainDigit = new Regex(@"^(.*\d.*)$").IsMatch(value.ToString());
                bool isContainLetter = new Regex(@"^(.*\p{L}.*)$").IsMatch(value.ToString());
                if (isContainDigit && isContainLetter)
                {
                    return ValidationResult.Success;
                }
            }
            string errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
