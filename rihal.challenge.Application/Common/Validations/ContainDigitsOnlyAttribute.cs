
using rihal.challenge.Application.Common.Utilities;
using System.ComponentModel.DataAnnotations;

namespace rihal.challenge.Application.Common.Validations
{
    public class ContainDigitsOnlyAttribute : ValidationAttribute
    {
        public ContainDigitsOnlyAttribute()
            : base("{0} must contain digits only")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool isContainOnlyDigit = NumericUtility.ContainOnlyDigits(value.ToString());
                if (isContainOnlyDigit)
                {
                    return ValidationResult.Success;
                }
            }
            string errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
