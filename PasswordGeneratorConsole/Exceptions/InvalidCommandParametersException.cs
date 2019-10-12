using System;

namespace PasswordGeneratorConsole.Exceptions
{
    public class InvalidCommandParametersException : Exception
    {
        public InvalidCommandParametersException(params string[] parameters) 
            : base($"Invalid parameters: \"{string.Join(", ", parameters)}\".")
        {
        }
    }
}
