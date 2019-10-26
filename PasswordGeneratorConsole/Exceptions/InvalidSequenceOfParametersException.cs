using System;

namespace PasswordGeneratorConsole.Exceptions
{
    public class InvalidSequenceOfParametersException : Exception
    {
        public InvalidSequenceOfParametersException() : base("Invalid sequence of parameters.")
        {
        }
    }
}
