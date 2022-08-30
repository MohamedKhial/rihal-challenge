using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace rihal.challenge.Application.Common.Validations
{
    public class ContainLettersAttribute : ValidationAttribute
    {
        public ContainLettersAttribute()
            : base("{0} must contain only letters")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool isContainDigit = new Regex(@"^[\p{L}0-9\s]+$").IsMatch(value.ToString());
                if (isContainDigit)
                {
                    return ValidationResult.Success;
                }
            }
            string errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
