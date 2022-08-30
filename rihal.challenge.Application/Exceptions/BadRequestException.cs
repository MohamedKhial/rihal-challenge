using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace rihal.challenge.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public BadRequestException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (ValidationFailure validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
        public BadRequestException(string errorMessage)
        {
            ValdationErrors.Add(errorMessage);
        }
    }
}
