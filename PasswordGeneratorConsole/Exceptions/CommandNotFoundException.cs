using System;

namespace PasswordGeneratorConsole.Exceptions
{
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException(string commandInput) : base($"Command \"{commandInput}\" not found.")
        {
        }
    }
}
