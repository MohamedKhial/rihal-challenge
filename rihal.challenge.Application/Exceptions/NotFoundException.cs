using System;

namespace rihal.challenge.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
