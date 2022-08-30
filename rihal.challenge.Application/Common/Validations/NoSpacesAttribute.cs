using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace rihal.challenge.Application.Common.Validations
{
    public class NoSpacesAttribute : ValidationAttribute
    {
        public NoSpacesAttribute()
            : base("White space is not allowed in {0}")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            Regex rgx = new Regex(@"^\S+$");
            bool isValid = rgx.IsMatch(value.ToString());
            if (isValid)
            {
                return ValidationResult.Success;
            }

            string errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }
    }
}
